using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BMI_Functions;



namespace BMI_Web_API__ASP.NET_FRAMEWORK_
{

    public partial class Calculator : System.Web.UI.Page
    {
        BmiFunctions tempAcct = new BmiFunctions();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void maleBtn_sub(object sender, ImageClickEventArgs e)
        {
            outputGenderLabel.Text = maleButton.UniqueID;
            //outputGenderLabel.Text = maleButton.AlternateText;
        }
        protected void femaleBtn_sub(object sender, ImageClickEventArgs e)
        {
            outputGenderLabel.Text = femaleButton.AlternateText;
        }

        protected void subweightBtnMethod(object sender, EventArgs e)
        {
            updateLabelTag(-1);
        }
        protected void subageBtnMethod(object sender, EventArgs e)
        {
            updateAgeLabelTag(-1);

        }
        protected void addweightBtnMethod(object sender, EventArgs e)
        {
            updateLabelTag(1);
        }

        protected void addageBtnMethod(object sender, EventArgs e)
        {
            updateAgeLabelTag(1);

        }

        private void updateLabelTag(int val)
        {
            int temp;
            if (int.TryParse(weightLabel.Text, out temp))
            {
                temp = temp + val;
                weightLabel.Text = temp.ToString();

                tempAcct.setWeight(temp);
            }
        }

        private void updateAgeLabelTag(int val)
        {
            int temp;
            if (int.TryParse(ageLabel.Text, out temp))
            {
                temp = temp + val;
                ageLabel.Text = temp.ToString();

            }
        }
    }


}