using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoApp;

namespace ToDoListGUI
{
    public partial class ToDoList : Form
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public ToDoList()
        {
            InitializeComponent();
            this.Text = "ToDoList";
        }

        private void UpdateTaskList()
        {
            lstTasks.Items.Clear();
            foreach (var task in tasks)
            {
                lstTasks.Items.Add(task);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTask.Text))
            {
                var task = new TaskItem { Description = txtTask.Text, IsDone = false };
                tasks.Add(task);
                UpdateTaskList();
                txtTask.Clear();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                tasks.RemoveAt(lstTasks.SelectedIndex);
                UpdateTaskList();
            }
        }

        private void lstTasks_DoubleClick(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                tasks[lstTasks.SelectedIndex].IsDone = !tasks[lstTasks.SelectedIndex].IsDone;
                UpdateTaskList();
            }
        }

        private void btnMarkDone_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                tasks[lstTasks.SelectedIndex].IsDone = true;
                UpdateTaskList();
            }
        }
    }
}
