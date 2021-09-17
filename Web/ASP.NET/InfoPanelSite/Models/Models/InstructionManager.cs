using System;
using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class InstructionManager : BaseItemManager<Instruction>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null)
                return false;

            if (newValues["CultureInfo"] == null)
                return false;

            if (newValues["TextType"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(Instruction item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"]?.ToString();
            item.CultureInfo = newValues["CultureInfo"]?.ToString();
            item.Text = newValues["Text"]?.ToString();
            item.TextType = newValues["TextType"]?.ToString();
        }

        public readonly static InstructionManager DefaultManager = new InstructionManager();
    }
}
