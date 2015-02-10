SpriteOutlineFx
===============

*SpriteOutlineFx* is an image effect which adds outlines to sprites.

![Screenshot](http://keijiro.github.io/SpriteOutlineFx/screenshot.png)

Usage
-----

*SpriteOutlineFx* draws contour lines of alpha channel values.
The following points should be kept in mind.

- The alpha channel of the screen must be cleared by setting a zero
  alpha color to the camera's clear color.
- Use a color mask to draw sprites/objects without outlines.
  See [the Sprites-NoAlpha shader][example] for a detailed usage example.

[example]: https://github.com/keijiro/SpriteOutlineFx/blob/master/Assets/Test/Sprites-NoAlpha.shader
