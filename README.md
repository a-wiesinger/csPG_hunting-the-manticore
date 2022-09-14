# csPG_hunting-the-manticore

// Criteria:
//
// *** Est. game start state with Manticore HP at 10, City at 15
// *** Ask the first player to enter the Manticore's starting position ( 0 - 100 )
// *** Clear screen
// *** Game loop runs until either the City or the Manticore's HP drops to 0 (or below)
// *** Before player 2's round starts, display the following:
    // - round number
    // - City HP
    // - Manticore HP
// *** Compute cannon damage:
    // - (if round number % 3 || 5 == 0 then dmg = 3)
        // 3 = Fire Blast
        // 5 = Electric Blast
    // - (if round number % 3 && 5 == 0 then dmg = 10) (Electrifyre Blast)
    // - Use different colors for the different shot types
    // - Tell the player what the upcoming damage will be
// *** - Get target range from player 2 ( 0 - 100 )
    // Tell player 2 if they under or overshot
    // Resolve effect of shot (dmg resolves on Manticore possibly)
// *** - If Manticore still lives, the City suffers -1 HP
// *** Advance to next round
// *** When Manticore or City health drops to 0, the game is over