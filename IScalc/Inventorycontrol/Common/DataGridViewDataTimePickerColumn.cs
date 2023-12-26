using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventorycontrol.Common
{
    public class DataGridViewDataTimePickerColumn : DataGridViewColumn
    {
        // DataGridViewのカラムにDateTimePickerを適用するためのカスタムセルクラス

        public DataGridViewDataTimePickerColumn() : base(new DataGridViewDataTimePickerCell())
        {
        }

        private DateTime maskValue = DateTime.Today;

        public DateTime Mask
        {
            get
            {
                return this.maskValue;
            }
            set
            {
                this.maskValue = value;
            }
        }


        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (!(value is DataGridViewDataTimePickerCell))
                {
                    throw new InvalidCastException("DataGridViewDataTimePickerCellオブジェクトを" +
                                                   "指定してください。");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class DataGridViewDataTimePickerCell : DataGridViewTextBoxCell
    {
        public DataGridViewDataTimePickerCell()
        {

        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DataGridViewDataTimePickerEditingControl picker = 
                              this.DataGridView.EditingControl as DataGridViewDataTimePickerEditingControl;
            if(picker != null)
            {
                picker.Value = (DateTime)this.Value;
                DataGridViewDataTimePickerColumn column = this.OwningColumn as DataGridViewDataTimePickerColumn;
                if(column != null)
                {
                    picker.Value = column.Mask;
                }
            }
        }
        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewDataTimePickerEditingControl);
            }
        }
        public override Type ValueType
        {
            get
            {
                return typeof(object);
            }
        }
        public override object DefaultNewRowValue
        {
            get
            {
                return base.DefaultNewRowValue;
            }
        }
    }

    public class DataGridViewDataTimePickerEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;

        int rowIndex;

        bool valueChanged;

        public DataGridViewDataTimePickerEditingControl()
        {
            this.TabStop = false;
        }

        #region IDataGridViewEditingControl メンバ

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            DateTime? value = (DateTime?)this.EditingControlFormattedValue;
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return value.Value.ToString(this.CustomFormat);
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return this.GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                this.Text = (string)value;
            }
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return this.dataGridView;
            }
            set
            {
                this.dataGridView = value;
            }
        }
        public int EditingControlRowIndex
        {
            get
            {
                return this.rowIndex;
            }
            set
            {
                this.rowIndex = value;
            }
        }
        public bool EditingControlValueChanged
        {
            get
            {
                return this.valueChanged;
            }
            set
            {
                this.valueChanged = value;
            }
        }
        public bool EditingControlWantsInputKey(Keys keyData,bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Right:
                case Keys.End:
                case Keys.Left:
                case Keys.Home:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        void IDataGridViewEditingControl.PrepareEditingControlForEdit(bool selectAll)
        {
            
        }

        #endregion
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.valueChanged = true;
            this.dataGridView.NotifyCurrentCellDirty(true);
        }

       
    }
}




