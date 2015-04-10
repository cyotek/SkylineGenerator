Change Log
==========

1.1.0.0
-------

* Presets are now JSON files and program allows you to create your own
* Added a new `Mirror` option to building styles. When set, the building will been mirrored using another style, creating an effect similar to the [original image](http://www.ansdor.com/post/105913561346) that inspired this tool
* Added a new `GrowWindows` option to building styles. When set, windows have a chance to be double width, allowing for more interesting window patterns than a plain grid
* Added a new `Wrap` option. When set, buildings can no longer be positioned outside the main boundaries, allowing for seamless horizontal tiling
* If the seed is 0, the same seed of `Environment.TickCount` is now used for all the different randoms, instead of potentially each random having a different seed
* Current seed is now displayed in the status bar

1.0.0.1
-------

* Fixes a crash if generation was occurring while a VS designer was clearing the buildings collection
* Fixes a crash if the maximum building size was smaller than the minimum building size

1.0.0.0
-------

* Initial Release