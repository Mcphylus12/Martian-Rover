## Overview
Martian rover Kata variant for red badger interview

## Prereqs
- .NET 10 SDK

## Running
The main entry point is the CLI.
Can be published if desired but for ease I recommend straight from source with `dotnet run -- <path to file containing input>`.
give it a file containing input similar to the sample input and it will print the output to standard out.

## Planning

> Note on spec.
>
> The scent left by robots doesnt include direction so if a robot in a corner tile (EG top-right) moves off by going north the spec indicates the scent will prohibit future robots going east or north. I will implement strictly to the spec but in a real world environment would double check this as a desired behaviour from the stakeholder/PM/PO. Teh alternative being the scent is valid only for the direction that robot fell off and 2 robots can fall off of corner tiles if in different directions.

0. Made rubbish image to picture sample input and output
1. Implement tests based on sample input and output
2. Implement CLI entry that takes a file in and writes to std out
3. Implement Basic movement w/ tests. **Generic String to command handler**
4. Implement LOST output and position validation
5. Implement "Scent" behaviour w/ tests. In an attempt to make the implementation true to the concept of a "scent". I'll add it as a scent object in the "Level" as opposed to a "Command and Control" approach where last known positions are reigstered into some sort of containers of lost robots.


While implementing scent handling it seemed like it ended up being a registry anyway its just the level was the container as opposed to some new manager object. IMO this makes sense that the level knows which scents are present and where. Just odd now the level knows about scents but not the robots.


## Further work
The main thing im not super happy with is the commands still being a char array. I toyed with 2-3 ideas but ran out of time at ~2 hours and left it as is.

- Move char to a `RobotCommand` enum but keep structure pretty much the same. This strong types available commands, removes primitive obsession.
   - An expanstion of this here each command is a POCO. command resolution is down with pattern matching but the POCO allows a parse function to be added and parameterised commands if needed in the future
- The big alternative was moving the mutation of the robot state itself to an `Execute` function on the commands EG the command design pattern. This adds the ability to add more commands more easily but my concern is the gain is temporary and long term quality degrades as the robot no longer controls its own state and capabilities (for example you cant lock down that a valid position if any class can make arbitrary updates to a robots XY coords as long as it has a reference). I dont believe the loss to encapsulation is worth it when it makes intuitive sense the robot class/file would change to support a new command anyway.

