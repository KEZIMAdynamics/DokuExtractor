using DokuExtractorStandardGUI.UserControls;
using DokuExtractorStandardGUI.UserControlsTemplateEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorStandardGUI.Logic
{
    public static class UserControlSelector
    {
        public static string ViewerPluginPath { get; set; } = @"..\..\..\KezimaPdfViewer\bin\Debug\KezimaPdfViewer.dll";

        public static Type DataFieldClassTemplateUserControl { get { return dataFieldClassTemplateUserControl; } }
        public static Type DataFieldGroupTemplateUserControl { get { return dataFieldGroupTemplateUserControl; } }
        public static Type CalculationFieldGroupTemplateUserControl { get { return calculationFieldGroupTemplateUserControl; } }
        public static Type ConditionalFieldTemplateUserControl { get { return conditionalFieldTemplateUserControl; } }

        public static Type ExtractedDataFieldsUserControl { get { return extractedDataFieldsUserControl; } }
        public static Type ExtractedCalculationFieldsUserControl { get { return extractedCalculationFieldsUserControl; } }
        public static Type ExtractedConditionalFieldsUserControl { get { return extractedConditionalFieldsUserControl; } }

        private static Type dataFieldClassTemplateUserControl = typeof(ucDataFieldClassTemplate);
        private static Type dataFieldGroupTemplateUserControl = typeof(ucDataFieldGroupTemplate);
        private static Type calculationFieldGroupTemplateUserControl = typeof(ucCalculationFieldGroupTemplate);
        private static Type conditionalFieldTemplateUserControl = typeof(ucConditionalFieldTemplate);

        private static Type extractedDataFieldsUserControl = typeof(ucExtractedDataFields);
        private static Type extractedCalculationFieldsUserControl = typeof(ucExtractedCalculationFields);
        private static Type extractedConditionalFieldsUserControl = typeof(ucExtractedConditionalFields);

        public static void SetViewerPluginPath(string viewerPluginPath)
        {
            ViewerPluginPath = viewerPluginPath;
        }

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

        public static void RegisterExtractedDataFieldsUserControl<T>() where T : ucExtractedDataFields
        {
            extractedDataFieldsUserControl = typeof(T);
        }

        public static void RegisterExtractedCalculationFieldsUserControl<T>() where T : ucExtractedCalculationFields
        {
            extractedCalculationFieldsUserControl = typeof(T);
        }

        public static void RegisterExtractedConditionalFieldsUserControl<T>() where T : ucExtractedConditionalFields
        {
            extractedConditionalFieldsUserControl = typeof(T);
        }
    }
}
