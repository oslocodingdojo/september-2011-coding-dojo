class GameOfLife 

  constructor: (@board) ->
    unless @board
      @board = ([] for row in [0..50])
      for row in [0..@board.length-1]
        for column in [0..50]
          @board[row][column] = if Math.random() > 0.8 then 'x' else ' '    
  
  tick: -> 
    next_generation = ([] for row in [0..@board.length-1])
    for row in [0..@board.length-1]      
      for column in [0..@board[row].length-1]
        if @board[row][column] == 'x'
          next_generation[row][column] = if @count_neighbours(row, column) == 2 || @count_neighbours(row, column) == 3 then 'x' else ' '
        else
          next_generation[row][column] = if @count_neighbours(row, column) == 3 then 'x' else ' '
    @board = next_generation
  
  count_neighbours: (row,column) ->
    count = 0
    count++ if @has_cell(row-1, column-1)
    count++ if @has_cell(row-1, column)
    count++ if @has_cell(row-1, column+1)
    count++ if @has_cell(row, column-1)
    count++ if @has_cell(row, column+1)
    count++ if @has_cell(row+1, column-1)
    count++ if @has_cell(row+1, column)
    count++ if @has_cell(row+1, column+1)
    count
  
  column: (index) ->
    (row[index] for row in @board)
    
  row: (index) ->
    @board[index]
  
  has_cell: (row,column) -> 
    @board[row] && @board[row][column] == 'x'
    
  view: ->
    console.log ""
    console.log '|' + @board[0].join("") + '|'
    console.log '|' + @board[1].join("") + '|'
    console.log '|' + @board[2].join("") + '|'

  draw: (func) ->
    for row in [0..@board.length-1]
      for column in [0..@board[row].length-1]
        func row, column, @has_cell(row, column)
      
    
exports.GameOfLife = GameOfLife