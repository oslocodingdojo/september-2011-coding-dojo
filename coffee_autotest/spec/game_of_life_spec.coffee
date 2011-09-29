game_of_life = require '../src/game_of_life'

GameOfLife = game_of_life.GameOfLife

describe 'Board with lonely cell', ->

  game = new GameOfLife [
           [' ', ' ', ' '],
           [' ', ' ', ' '],
           [' ', 'x', ' ']
          ]
  
  it 'should recognize squares with cells', ->
    expect(game.row(2)[1]).toEqual 'x'

  it 'should kill lonely cells', ->
    game.tick()
    expect(game.row(2)[1]).toEqual ' '
  

describe 'Surviving cells', ->

  it 'should survive with horizontal neighbours', ->
    game =  new GameOfLife [['x', 'x', 'x']
                            [' ', ' ', ' ']
                            [' ', ' ', ' ']]
    game.tick()
    expect(game.row(0)).toEqual([' ', 'x', ' '])
    
  it 'should survive with vertical neighbours', ->
    game =  new GameOfLife [[' ', 'x', ' ']
                            [' ', 'x', ' ']
                            [' ', 'x', ' ']]
    game.tick()
    expect(game.column(1)).toEqual([' ', 'x', ' '])


  it 'should survive with diagonal neighbours', ->
    game = new GameOfLife [['x', ' ', ' ']
                           [' ', 'x', ' ']
                           [' ', ' ', 'x']]
    game.tick()
    expect(game.column(1)[1]).toEqual 'x'
    
  it 'should survive with three neighbours', ->
    game = new GameOfLife [['x', 'x', 'x']
                           [' ', 'x', ' ']
                           [' ', ' ', ' ']]
    game.tick()
    expect(game.column(1)[1]).toEqual 'x'    

describe 'Crowded cells', ->

  it 'should die with too many neighbours', ->
    game =  new GameOfLife [['x', 'x', 'x']
                            [' ', 'x', ' ']
                            [' ', 'x', ' ']]
    game.tick()
    expect(game.row(1)).toEqual([' ', ' ', ' '])
  
describe 'Kinky cell-sex', ->
  it 'should reproduce with exactly three neighbours', ->
    game = new GameOfLife [[' ', ' ', ' ']
                           ['x', ' ', 'x']
                           [' ', ' ', 'x']]
    game.tick()
    expect(game.row(0)).toEqual [' ', ' ', ' ']
    expect(game.row(1)).toEqual [' ', 'x', ' ']
    expect(game.row(2)).toEqual [' ', 'x', ' ']
    console.log game.view()
    
    
describe 'Given a board', ->
  it 'should draw board', ->
    game = new GameOfLife [[' ', ' ', ' ']
                           ['x', ' ', 'x']
                           [' ', ' ', 'x']]
    cells = []
    game.draw (row,column,has_cell) ->
      cells[row] ||= []
      cells[row][column] = has_cell
    expect(cells[1]).toEqual [true,false,true]
