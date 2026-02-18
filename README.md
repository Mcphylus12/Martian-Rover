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



