# Control landing system library

This library helps a rocket to determine if it can land on a platform or not.

## TL;DR;

 ```
 LandingControl control = new LandingControl();

 string reponse = control.LandingRequest(5, 5);
 ```

## Assumptions

 - _Landing area_: consists of multiple squares described with an x, y coordinate.
 - _Top left corner_ of the landing area is at 1,1.
 - _Landing area_ dimension is 100 x 100.
 - _Landing platform_ also consists of multiple squares described with an x, y coordinate.
 - _Landing platform_ must fit within the landing area.
 - _Top left corner_ of the landing platform is at 5,5.
 - _Size_ of landing platform can be configurable.

 ## Use

 Just add the library to our project, create the _LandingControl_ object, and start asking for the rocket landing coordinates:

 ```
 LandingControl control = new LandingControl();

 string reponse = control.LandingRequest(5, 5);
 ```
 or, if you prefer to use Coordinates

 ```
 LandingControl control = new LandingControl();

 Coordinate rocket01 = new Coordinate(5, 5);
 string reponse = control.LandingRequest(rocket01);
 ```

 If the desired landing platform does not fit into the landing area an Exception is raised informing of that.

 - Is the rocket ask for a valid (within landing platform) position, library answer: `ok for landing`.
 - If the rocket asks for an invalid (outside landing platform) position `out of platform` will be answered.
 - If the rocket asks for a position where the previous rocket has checked or its nearest positions `clash` will be answered,
 independently if this position is within or outside landing platform.

 ## Flawkness

 - Landing Platform top left corner is fixed.
 - Landing Platform and landing area are squares and only squares.
 - The behavior when a rocket asks for a coordinate outside the landing area is not defined. Currently `out of platform` is answered (unless `clash`case).