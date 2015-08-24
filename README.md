[![Coverity Scan Build Status](https://img.shields.io/coverity/scan/6125.svg)](https://scan.coverity.com/projects/melcloud-football-exercise)
[![Build status](https://ci.appveyor.com/api/projects/status/8k5322n7ojn959fs/branch/master?svg=true)](https://ci.appveyor.com/project/melcloud/football-exercise/branch/master)

# Introduction #
The file football.dat contains the results from the English Premier League. The columns ‘F’ and ‘A’ contain the total number of goals scored for and against each team in that season (so Arsenal scored 79 goals against opponents, and had 36 goals scored against them).

Write a program to print the name of the team with the smallest difference in ‘for’ and ‘against’ goals.

If you wish, you may use football.csv instead of football.dat to get the data.

# Assumption #
1. The CSV file struture will remain as sample. There will be nine columns and in the order of how they are defined now.
2. The CSV file is small enough to be loaded into memory directly.
3. The CSV file does not contain comma in each column value.
4. The first row of CSV file is always the header row.

# To do #
1. Improve CSV load, such as using an existing library. The libary should achieve following goals:

	a. Can reference each column value by its header
	b. Batch process lines instead of reading them all into memory
	c. Can parse column value correctly even they contain comma
2. Improve performance on calculating minimum difference of goal. This can acchieved by using BufferBlock, ActionBlock and async Task. It also can benefits from pipeline pattern.
3. Improve logging
4. Process multiple files from one directory
5. Benchmark
4. F# ?