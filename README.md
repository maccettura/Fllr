# fllr.art

Web [![Netlify Status](https://api.netlify.com/api/v1/badges/07ac06fd-9e5c-454c-8c7a-2598072c7aeb/deploy-status)](https://app.netlify.com/sites/fllr/deploys)

### Overview

Fllr.art is a .NET 5 web app that generates FPO images based on a set of parameters. It is built using [ImageSharp](https://github.com/SixLabors/ImageSharp).

### How to Use

Visit [Fllr.art](https://www.fllr.art) for a simple form that generates an image link, an image tag and an actual image based on _your_ parameters.

The easiest way to generate an FPO image is to simply pass a width and a height: `/400x400.jpg`

<img src="https://i.fllr.art/400x400.jpg" />

There are a number of optional parameters as well:

#### Colors

You can provide overrides for the default text and background colors: `/91F5AD/000000/400x400.jpg`

<img src="https://i.fllr.art/91F5AD/000000/400x400.jpg" />

#### Text & Font

The default font of generated images is [Montserrat](https://fonts.google.com/specimen/Montserrat), but you can optionally set the font via query string (`f=`). Currently only Montserrat and [PT Serif](https://fonts.google.com/specimen/PT+Serif) are supported.

The default text of the generated image is the `"{width} x {height}"`, but you can change the text via query string (`t=`). The max length of a text parameter is 100 characters.

A 400x400 image with the PT Serif font and the text "Hello World": `/400x400.jpg?t=Hello%20World&f=pt serif`

<img src="https://i.fllr.art/400x400.jpg?t=Hello%20World&f=pt%20serif" />
