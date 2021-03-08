using System;
using ProjectVaka.Entity;
using ProjectVaka.Keys;
using ProjectVaka.Log;
using ProjectVaka.Statics;

namespace ProjectVaka.Base
{
    public abstract class UserKeyEntry
    {
        public Robot _robot;

        public UserKeyEntry(Robot robot)
        {
            _robot = robot;
        }

        protected abstract bool ForceAcceptableValueImpl(MoveKey moveKey);

        public void ForceAcceptableValue()
        {
            bool isExistsTriggered = false;
            do
            {
                try
                {
                    MoveKey moveKey;
                    if (StaticMethods.EnterMoveKey(out moveKey))
                        isExistsTriggered = ForceAcceptableValueImpl(moveKey);
                }
                catch (Exception exc)
                {
                    Loger.Write(Console.Out.NewLine + string.Format(@"Beklenmeyen bir hata oluştu. Hata Açıklaması: {0}", exc.Message));
                    isExistsTriggered = false;
                }
            } while (!isExistsTriggered);

            _robot.Commands.ExecuteCommands();
        }
    }
}
