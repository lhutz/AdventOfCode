using System;
using System.Linq;
using Tidy.AdventOfCode;

namespace AdventOfCodeYear2021
{
    [Day(2021, 2)]
    public class Day2: Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            var submarine = new Submarine();
            ApplyMovements(submarine);
            return submarine.Depth * submarine.Progress;
        }

        public override object ExecutePart2()
        {
            var submarine = new SecondSubmarine();
            ApplyMovements(submarine);
            return submarine.Progress * submarine.Depth;
        }

        private void ApplyMovements(Submarine submarine)
        {
            var movements = Input
                .Select(movement =>
                {
                    var values = movement.Split(" ", StringSplitOptions.TrimEntries);
                    return (values[0], int.Parse(values[1]));
                });

            foreach (var (direction, speed) in movements)
            {
                submarine.Move(direction, speed);
            }
        }
    }

    public class SecondSubmarine : Submarine
    {
        public SecondSubmarine()
        {
            this.Aim = 0;
        }

        public int Aim { get; private set; }

        protected override void GoForward(int speed)
        {
            base.GoForward(speed);
            this.Depth += speed * Aim;
        }

        protected override void GoUp(int speed)
        {
            this.Aim -= speed;
        }

        protected override void GoDown(int speed)
        {
            this.Aim += speed;
        }
    }

    public class Submarine
    {
        public Submarine()
        {
            Depth = 0;
            Progress = 0;
        }
        public int Depth { get; protected set; }
        public int Progress { get; protected set; }

        public void Move(string direction, int speed)
        {
            switch (direction)
            {
                case "forward":
                    GoForward(speed);
                    break;
                case "up":
                    GoUp(speed);
                    break;
                case "down":
                    GoDown(speed);
                    break;
            }
        }

        protected virtual void GoForward(int speed)
        {
            Progress += speed;
        }

        protected virtual void GoUp(int speed)
        {
            Depth -= speed;
        }

        protected virtual void GoDown(int speed)
        {
            Depth += speed;
        }
    }
}