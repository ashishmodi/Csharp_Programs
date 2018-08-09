using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace BankQueueSystem_WebForm
{
    public partial class BankingQueue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TokenQueue"] == null)
            {
                Queue<int> qTokens = new Queue<int>();
                Session["TokenQueue"] = qTokens;
            }
        }

        protected void btnPrintToken_Click(object sender, EventArgs e)
        {
            Queue<int> qTokens = (Queue<int>)Session["TokenQueue"];
            lblPendingTokens.Text = "There are " + qTokens.Count + " customers before you";

            if (Session["NextTokenTobeIssued"] == null)
            {
                Session["NextTokenTobeIssued"] = 0;
            }
            int iNextToken = (int)Session["NextTokenTobeIssued"] + 1;
            Session["NextTokenTobeIssued"] = iNextToken;
            qTokens.Enqueue(iNextToken);
            AddTokensToListbox(ref qTokens);
        }

        protected void AddTokensToListbox(ref Queue<int> tokens)
        {
            lstTokens.Items.Clear();
            foreach (int token in tokens)
            {
                lstTokens.Items.Add(token.ToString());
            }
        }
        
        private void ProcessToken(TextBox txtCurrentCounter, string sCounter)
        {
            Queue<int> qToken = (Queue<int>)Session["TokenQueue"];
            if (qToken.Count == 0)
            {
                txtCurrentCounter.Text = "There are no customers in the queue";
                txtUserMessage.Text = "No customers waiting in Queue";
                lblPendingTokens.Text = "";
            }
            else
            {
                int iTurn = qToken.Dequeue();
                txtUserMessage.Text = "Token no " + iTurn + " please goto " + sCounter;
                txtCurrentCounter.Text = iTurn.ToString();
                AddTokensToListbox(ref qToken);
            }            
        }

        protected void btnCounter1_Click(object sender, EventArgs e)
        {
            ProcessToken(txtCounter1, "Counter 1");
        }

        protected void btnCounter2_Click(object sender, EventArgs e)
        {
            ProcessToken(txtCounter2, "Counter 2");
        }

        protected void btnCounter3_Click(object sender, EventArgs e)
        {
            ProcessToken(txtCounter3, "Counter 3");
        }
    }
}