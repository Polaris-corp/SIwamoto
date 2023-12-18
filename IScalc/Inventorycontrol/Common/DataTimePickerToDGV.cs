using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventorycontrol.Common
{
    public class DataTimePickerToDGV : DataGridViewColumn
    {
        // DataGridViewのカラムにDateTimePickerを適用するためのカスタムセルクラス
        public class DateTimePickerCell : DataGridViewCell
        {
            public DateTimePickerCell() : base()
            {
                // セルのデフォルトの値を設定
                this.Value = DateTime.Now;
            }

            // セルの編集コントロールを初期化
            public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

                var ctl = DataGridView.EditingControl as DateTimePickerEditingControl;
                if (ctl != null)
                {
                    // データバインドの設定や初期値のセットなど
                    ctl.Value = (DateTime)this.Value;
                    // その他DateTimePickerのプロパティ設定など
                }
            }

            // セルの型
            public override Type EditType
            {
                get { return typeof(DateTimePickerEditingControl); }
            }

            // セルの値の型
            public override Type ValueType
            {
                get { return typeof(DateTime); }
            }

            // セルのデフォルト値
            public override object DefaultNewRowValue
            {
                get { return DateTime.Now; }
            }
        }

        // DataGridViewのセルに表示するDateTimePickerの編集コントロール
        public class DateTimePickerEditingControl : DateTimePicker, IDataGridViewEditingControl
        {
            DataGridView dataGridView;
            private bool valueChanged = false;
            int rowIndex;

            public DateTimePickerEditingControl()
            {
                this.Format = DateTimePickerFormat.Short;
            }

            public object EditingControlFormattedValue
            {
                get { return this.Value.ToShortDateString(); }
                set
                {
                    if (value is String)
                    {
                        try
                        {
                            this.Value = DateTime.Parse((String)value);
                        }
                        catch
                        {
                            this.Value = DateTime.Now;
                        }
                    }
                }
            }

            public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
            {
                return EditingControlFormattedValue;
            }

            public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
                this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
                this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
            }

            public int EditingControlRowIndex
            {
                get { return rowIndex; }
                set { rowIndex = value; }
            }

            public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
            {
                return !dataGridViewWantsInputKey;
            }

            public void PrepareEditingControlForEdit(bool selectAll)
            {
                // No preparation needs to be done.
            }

            public bool RepositionEditingControlOnValueChange
            {
                get { return false; }
            }

            public DataGridView EditingControlDataGridView
            {
                get { return dataGridView; }
                set { dataGridView = value; }
            }

            public bool EditingControlValueChanged
            {
                get { return valueChanged; }
                set { valueChanged = value; }
            }

            public Cursor EditingPanelCursor
            {
                get { return base.Cursor; }
            }

            protected override void OnValueChanged(EventArgs eventargs)
            {
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnValueChanged(eventargs);
            }
        }

    }


}

