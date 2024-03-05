using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan.controller
{
    public class ViewControl
    {
        protected ModelControl modelControl;

        /// <summary>
        /// constructor, that makes sure, all children have the modelControl
        /// </summary>
        /// <param name="modelControl"></param>
        public ViewControl(ModelControl modelControl)
        {
            this.modelControl = modelControl;
        }

    }
}
