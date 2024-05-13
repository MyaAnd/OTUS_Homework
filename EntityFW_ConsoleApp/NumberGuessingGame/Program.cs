using NumberGuessingGame.Classes;
using NumberGuessingGame.Interfaces;
using System.Reflection.Metadata.Ecma335;

Main();

static void Main()
{
    List<IRangedDifficultyConfiguration> difList = new List<IRangedDifficultyConfiguration>()
            {
                new EasyDifficulty(),
                new NormalDifficulty(),
                new HardDifficulty()
            };

    IDifficultySelector difSelector = new DifficultySelector(difList);

    //DependencyInjection
    Game currentGame = new Game(difSelector);
    currentGame.RunGame();
}




