using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateLab
{
    abstract class GeneralParaser
    {
        #region PrivateMethod
        private void PrintMethodName()
        {
            string methodname = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Console.WriteLine($"Current method name is {methodname}");
        }
        #endregion
        #region Public Methods
        public void Wish(string pmname) {
            Console.WriteLine($"success from {pmname}");
        }
#endregion
        #region AbstractMethods
        protected abstract void Load();
        protected abstract void Parse();
        public abstract void Welcome();
        #endregion
        #region VirtualMethod
        protected virtual void Dump()
        {
            Console.WriteLine("Dump data in to oracle");
        }

        public virtual void TestPublic()
        {
            Console.WriteLine("Dump data in to oracle");
        }
        #endregion
        #region Template Method

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Process()
        {
            Load();
            Parse();
            Welcome();
            Dump();

        }
        #endregion

    }

}
