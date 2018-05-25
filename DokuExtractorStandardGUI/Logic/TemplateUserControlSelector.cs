using DokuExtractorStandardGUI.UserControlsTemplateEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorStandardGUI.Logic
{
    public static class TemplateUserControlSelector
    {
        public static Type DataFieldClassTemplateUserControl { get { return dataFieldClassTemplateUserControl; } }
        public static Type DataFieldGroupTemplateUserControl { get { return dataFieldGroupTemplateUserControl; } }
        public static Type CalculationFieldGroupTemplateUserControl { get { return calculationFieldGroupTemplateUserControl; } }
        public static Type ConditionalFieldTemplateUserControl { get { return conditionalFieldTemplateUserControl; } }

        private static Type dataFieldClassTemplateUserControl = typeof(ucDataFieldClassTemplate);
        private static Type dataFieldGroupTemplateUserControl = typeof(ucDataFieldGroupTemplate);
        private static Type calculationFieldGroupTemplateUserControl = typeof(ucCalculationFieldGroupTemplate);
        private static Type conditionalFieldTemplateUserControl = typeof(ucConditionalFieldTemplate);

        public static void RegisterDataFieldClassTemplateUserControl<T>() where T : ucDataFieldClassTemplate
        {
            dataFieldClassTemplateUserControl = typeof(T);
        }

        public static void RegisterDataFieldGroupTemplateUserControl<T>() where T : ucDataFieldGroupTemplate
        {
            dataFieldGroupTemplateUserControl = typeof(T);
        }

        public static void RegisterCalculationFieldGroupTemplateUserControl<T>() where T : ucCalculationFieldGroupTemplate
        {
            calculationFieldGroupTemplateUserControl = typeof(T);
        }

        public static void RegisterConditionalFieldGroupTemplateUserControl<T>() where T : ucConditionalFieldTemplate
        {
            conditionalFieldTemplateUserControl = typeof(T);
        }
    }
}
