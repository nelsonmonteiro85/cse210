public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    private Random random = new Random();

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted == _target)
        {
            return _points + _bonus;
        }
        else if (_amountCompleted > _target)
        {
            return _points;
        }
        return _points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
    }

    public override string GetDetailsString()
    {
        return $"[{(_amountCompleted >= _target ? "X" : " ")}] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public void Complete()
    {
        DisplayFireworks();
        Console.WriteLine("Congratulations! You just completed a checklist goal and have been awarded with bonus points!!!");
    }

    private void DisplayFireworks()
    {
        Console.CursorVisible = false; // Hide the cursor

        Console.Clear();

        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            switch (random.Next(6))
            {
                case 0:
                    DisplayFireworkPattern1();
                    break;
                case 1:
                    DisplayFireworkPattern2();
                    break;
                case 2:
                    DisplayFireworkPattern3();
                    break;
                case 3:
                    DisplayFireworkPattern4();
                    break;
                case 4:
                    DisplayFireworkPattern5();
                    break;
                case 5:
                    DisplayFireworkPattern6();
                    break;
            }

            Thread.Sleep(1000); // Adjust the sleep duration to control the speed of the animation
            Console.Clear();
            Thread.Sleep(100); // Add a pause between each iteration of the animation
        }
    }

    private void DisplayFireworkPattern1()
    {
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"   `  *  ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"  *    #         *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"   *            `   ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"     *    * #    *");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"   *             *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"     #    *             ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@" `  *     *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"          *   #  ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"  *    `   *   ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"   *        * ");
        Console.ResetColor();
    }

    private void DisplayFireworkPattern2()
    {
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"     *      *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"          * #         ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"  *    *       `   ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"         *     *      ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"   *  `   *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"         * #    *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"             *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"  *     ");
        Console.ResetColor();
    }

    private void DisplayFireworkPattern3()
    {
        Console.WriteLine(@"   *        ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"  *   `   *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"     * #      *   ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"    *   *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"  *          `   *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"        *   ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"      *  #  ");
        Console.ResetColor();
        Console.WriteLine(@"  *    `   *    ");
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"   *  ");
        Console.ResetColor();
    }

    private void DisplayFireworkPattern4()
    {
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"   *      *  ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"  * #          # *     ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"   *               *   ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"      *  * #         *");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"    *     *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"     #   #    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@" `          *     *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"      *   #     ");
        Console.ResetColor();
        Console.WriteLine(@"    *    `     *   ");
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"   *  ");
        Console.ResetColor();
    }

    private void DisplayFireworkPattern5()
    {
        Console.WriteLine(@"     *  ");
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"            * #         *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"   *   *   `   ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"          *        *   ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"   *  `       *    ");
        Console.ResetColor();
        Console.WriteLine(@"               * # *  ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"      *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.ResetColor();
        Console.WriteLine(@"  *   ");
    }

    private void DisplayFireworkPattern6()
    {
        Console.WriteLine(@"   *  ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"  *    `    *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"                #  *   ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"    *             *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"  *   `   *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"             *       ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"     *  #  ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"  *     `   *    ");
        Console.ResetColor();
        Console.ForegroundColor = GetRandomConsoleColor();
        Console.WriteLine(@"             *    ");
        Console.ResetColor();
    }

    private ConsoleColor GetRandomConsoleColor()
    {
        var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        return (ConsoleColor)consoleColors.GetValue(random.Next(consoleColors.Length));
    }
}
