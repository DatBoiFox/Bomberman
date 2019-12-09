using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources.Command;

namespace Client.Resources.Interpreter
{
    class ExpressionExecutor
    {
        private string expressionText;
        private RemoteControl remoteControl;
        private Player player;

        public ExpressionExecutor(RemoteControl remoteControl, Player player)
        {
            this.remoteControl = remoteControl;
            this.player = player;
            this.expressionText = Console.ReadLine();
            executeExpressions();
        }

        public void executeExpressions()
        {
            string[] expressions = splitIntoExpressionArray();
            List <AbstractExpression> expressionsList = makeExpressionsIntoObjects(expressions);
            foreach (var ex in expressionsList)
            {
                ex.execute();
            }
        }

        private string[] splitIntoExpressionArray()
        {
            char[] separators = new[] {' ', ',', ';', '.', '-'};
            string[] expressions = this.expressionText.Split(separators);
            return expressions;
        }

        private List<AbstractExpression> makeExpressionsIntoObjects(string[] expressions)
        {
            List < AbstractExpression > expressionsList = new List<AbstractExpression>();
            foreach (string s in expressions)
            {
                if (s.ToLower().Contains("right") || s.ToLower().Contains("left") || s.ToLower().Contains("up") || s.ToLower().Contains("down"))
                {
                    MoveExpression temp = new MoveExpression(this.remoteControl, this.player, s.ToLower());
                    expressionsList.Add(temp);
                }
                else if (s.ToLower().Contains("undo"))
                {
                    UndoExpression temp = new UndoExpression(this.remoteControl, this.player, s.ToLower());
                    expressionsList.Add(temp);
                }
            }
            return expressionsList;
        }
    }
}
