<template>
    <div class="container">
        <div class="row">
            <div class="col-md-5 offset-md-1">
                <div class="form">
                    <h4>Required:</h4>
                    <div class="row mb-3">            
                        <div class="col">
                            <label for="width" class="form-label">Width</label>
                            <input v-model="v$.width.$model" id="width" type="text" class="form-control" :class="{ 'is-invalid': v$.width.$error }" placeholder="Width" aria-label="Width">                        
                            <div v-if="!v$.width.required" class="invalid-feedback">
                                Width is required
                            </div>
                            <div v-if="!v$.width.between" class="invalid-feedback">
                                Must be between 1-4000
                            </div>
                        </div>
                        <div class="col">
                            <label for="height" class="form-label">Height</label>
                            <input v-model="v$.height.$model" id="height" type="text" class="form-control" :class="{ 'is-invalid': v$.height.$error }" placeholder="Height" aria-label="Height">
                            <div v-if="!v$.height.required" class="invalid-feedback">
                                Height is required
                            </div>
                            <div v-if="!v$.height.between" class="invalid-feedback">
                                Must be between 1-4000
                            </div>
                        </div>
                    </div>
                    <h4>Optional:</h4>
                    <div class="row mb-3"> 
                        <div class="col">
                            <label for="text-color" class="form-label">Background Color</label>
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="background-color-addon" :style="bgColorStyle">#</span>
                                <input v-model="v$.backgroundColor.$model" id="background-color" type="text" class="form-control" :class="{ 'is-invalid': v$.backgroundColor.$error }" placeholder="D3D3D3" aria-label="Background Color" aria-describedby="background-color-addon">
                                <div v-if="!v$.backgroundColor.error" class="invalid-feedback">
                                    Invalid hex color
                                </div>
                            </div>
                        </div>           
                        <div class="col">
                            <label for="text-color" class="form-label">Text Color</label>
                            <div class="input-group mb-3">
                                <span class="input-group-text" id="text-color-addon" :style="textColorStyle">#</span>
                                <input v-model="v$.textColor.$model" id="text-color" type="text" class="form-control" :class="{ 'is-invalid': v$.textColor.$error }" placeholder="A9A9A9" aria-label="Text Color" aria-describedby="text-color-addon">
                                <div v-if="!v$.textColor.error" class="invalid-feedback">
                                    Invalid hex color
                                </div>
                            </div>
                        </div>
                        <p><small>Please note: you can provide both colors, or provide neither (and let the defaults apply). <strong>You cannot provide just one color</strong>.</small></p>
                    </div>
                    <div class="row mb-3">            
                        <div class="col-4">
                            <label for="font" class="form-label">Font</label>
                            <select id="font" v-model="font" class="form-select" aria-label="Font Selection">                
                                <option value="montserrat">Montserrat</option>
                                <option value="pt serif">PT Serif</option>
                            </select>
                        </div>
                        <div class="col-8">
                            <label for="text" class="form-label">Text</label>
                            <input v-model="text" id="text" type="text" class="form-control" placeholder="Lorem ipsum dolor..." aria-label="Text" maxlength="100">
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-12">
                            <div class="input-group mb-3">
                                <input v-model="imageUrl" type="text" disabled class="form-control" placeholder="" aria-label="Generated Image Url" aria-describedby="copy-to-clipboard">
                                <button @click="copyToClipboard(imageUrl)" class="btn btn-outline-secondary" type="button" id="copy-to-clipboar">Copy</button>
                            </div>
                            <div class="input-group mb-3">
                                <input v-model="imageTag" type="text" disabled class="form-control" placeholder="" aria-label="Generated Image Url" aria-describedby="copy-to-clipboard">
                                <button @click="copyToClipboard(imageTag)" class="btn btn-outline-secondary" type="button" id="copy-to-clipboar">Copy</button>
                            </div>
                        </div>
                    </div>
                </div>
    
            </div>
            <div class="col-md-5">
                <img v-if="!v$.$errors.length" v-bind:src="imageUrl" class="img-fluid" alt="Placeholder Image" />
                <img v-else class="img-fluid" src="/img/invalid.jpg" alt="Bad image" />
            </div>
        </div>  
    </div>  
    </template>

<script>
import useVuelidate from '@vuelidate/core'
import { required, between } from '@vuelidate/validators'
import { useToast } from "vue-toastification";

const isHexColor = function(input) {
    let regex = RegExp(/^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$/, 'igm');
    return regex.test("#" + input);
};

export default {
    name: "LinkGenerator",
    setup () {
        return {
            v$: useVuelidate()
        }
    },
    data: function () {
        return {
            width: 400,
            height: 400,
            textColor: '',
            backgroundColor: '',
            font: 'montserrat',
            text: ''
        }
    },
    validations: {
        width: {
            required,
            between: between(1, 4000),
        },
        height: {
            required,
            between: between(1, 4000),
        },
        backgroundColor: {
            isHexColor
        },
        textColor: {
            isHexColor
        }
    },
    computed: {
        imageUrl: function () {
            var emoji = this.getEmojiIfError();
            console.log(emoji);
            if(emoji){
                return emoji;
            }

            const baseUrl = `https://i.fllr.art`;

            var url;
            if(this.textColor && this.backgroundColor){
                url = `${baseUrl}/${this.backgroundColor}/${this.textColor}`;
            }
            else {
                url = baseUrl;
            }

            url = `${url}/${this.width}x${this.height}`;

            var hasText = false;
            if(this.text) {
                hasText = true;                
            }

            var hasFont = false;
            if(this.font && this.font != 'montserrat') {
                hasFont = true;
            }

            if(hasFont && hasText) {
                url = `${url}.jpg?t=${this.text}&f=${this.font}`;
            }
            else if(hasFont && !hasText) {
                url = `${url}.jpg?f=${this.font}`;
            }
            else if (hasText && !hasFont){
                url = `${url}.jpg?t=${this.text}`;
            }
            else {
                url = `${url}.jpg`;
            }

            return url;         
        },
        imageTag: function() {
            var emoji = this.getEmojiIfError();
            console.log(emoji);
            if(emoji){
                return emoji;
            }
            return `<img src="${this.imageUrl}" alt="${this.width}x${this.height} FPO image" />`;
        },
        textColorStyle: function(){
            if(this.textColor) {
                return 'color: #' + this.textColor;
            } 
            return '';
        },
        bgColorStyle: function(){
            if(this.backgroundColor) {
                return 'background-color: #' + this.backgroundColor;
            } 
            return '';
        }
    },
    methods : {
        copyToClipboard : function(text){
            var self = this;
            navigator.clipboard.writeText(text).then(function() {
                const toast = useToast();
                toast.info("Copied!", { timeout: 1000 });
            }, 
            function(err) {   
                console.log(err);         
            });
        },
        getEmojiIfError: function() {
            if(this.v$.$errors.length > 0) { 
                console.log('error found');
                var num = Math.floor(Math.random() * 5);

                if(num == 1){
                    return '(╯°□°)╯︵ ┻━┻';
                }
                else if(num == 2) {
                    return '(ಠ_ಠ)';
                }
                else if(num == 3) {
                    return 'ヽ( ಠ益ಠ )ﾉ';
                }
                else if(num == 4) {
                    return 'ಠಿ_ಠ';
                }
                else {
                    return '( ͡o ͜ʖ ͡o)';
                }
            }
        }
    }
}
</script>

<style>
    .Vue-Toastification__toast--info {
        background-color: #fff !important;
        color:#2B404E !important;
    }
</style>
