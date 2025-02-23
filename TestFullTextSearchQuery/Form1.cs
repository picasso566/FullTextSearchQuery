﻿// Copyright (c) 2019-2021 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//

using SoftCircuits.FullTextSearchQuery;
using System;
using System.Windows.Forms;

namespace TestFullTextSearchQuery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            FtsQuery query = new FtsQuery(addStandardStopWords: true, defaultToInflectional: false);
            //FtsQuery query = new FtsQuery(addStandardStopWords: true);
            txtSqlQuery.Text = query.Transform(txtSearchTerm.Text);
        }

        private void txtSearchTerm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
