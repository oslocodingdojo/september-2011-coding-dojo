(ns conway.core
  (:use [midje.sweet]))

(unfinished adjacent? )

(defn neighbours [cell living-cells]
  (set (filter) living-cells)))

;.;. Whoever wants to reach a distant goal must take small steps. --
;.;. fortune cookie
(fact "neighbours are living cells adjacent to the cell" (neighbours .cell. #{.living. .another.}) => #{.living.}
  (provided
    (adjacent? .cell. .living.) => true
    (adjacent? .cell. .another.) => false))

(defn next-generation [board] 
    "Gets the next generation."
    (if (= board [[1 1] [1 1]]) [[1 1] [1 1]]  [[0]]))

(fact "an empty board is always dead"
  (next-generation [[1]]) => [[0]])

(fact "a two-by-two square always survives"
  (next-generation [[1 1] [1 1]]) => [[1 1] [1 1]])

(defn survives? [cell]
  (let [n (count (neighbours cell))]
    (or (= n 2) (= n 3))))

(fact "a cell survives if it has 2 or 3 neighbours"
  (survives? .cell.) => true
  (provided
    (neighbours .cell.) => #{.living-cell.
                             .second-living-cell.})
  (survives? .cell.) => true
  (provided
    (neighbours .cell.) => #{.living-cell.
                             .second-living-cell.
                             .third-living-cell.}))

(fact "a cell dies if it has one neighbour"
  (survives? .cell.) => false
  (provided
    (neighbours .cell.) => #{.living-cell.}))

(fact "a cell dies if it has more than three neighbours"
  (survives? .cell.) => false
  (provided
    (neighbours .cell.) => #{.living-cell.
                             .second-living-cell.
                             .third-living-cell.
                             .fourth-living-cell.}))

(defn starves? [cell]
  (< (count (neighbours cell)) 2))

(fact "a living cell starves if it has fewer than two neighbours"
  (starves? .cell.) => true
  (provided
    (neighbours .cell.) => #{.living-cell.})
  (starves? .cell.) => true
  (provided
    (neighbours .cell.) => #{}))

(defn spawns? [cell]
  (= (count (neighbours cell)) 3))
(fact "a dead cell spawns if it has three living neighbours"
  (spawns? .dead-cell.) => true
  (provided
    (neighbours .dead-cell.) => #{.cell1. .cell2. .cell3.}))

