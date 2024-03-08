using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Contacts.Maui.Models;
//using Contact = Contacts.Maui.Models.Contact;
//namespace Contacts.Maui.Views;

namespace Contacts.Maui.Views.Controls;

public partial class ContactControl : ContentView
{

    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;

    public ContactControl()
	{
		InitializeComponent();
	}

	public string Name
	{

		get
		{
			return entryName.Text;
		}
		set
		{
			entryName.Text = value;
		}
	}

    public string Email
    {

        get
        {
            return entryEmail.Text;
        }
        set
        {
            entryEmail.Text = value;
        }
    }
    public string Address
    {

        get
        {
            return entryAddress.Text;
        }
        set
        {
            entryAddress.Text = value;
        }
    }

    public string Phone
    {

        get
        {
            return entryPhone.Text;
        }
        set
        {
            entryPhone.Text = value;
        }
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {

        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name is required.");
            return;
        }

        if (!emailValidator.IsNotValid)
        {
            OnSave?.Invoke(sender, e);
        }
        else
        {
            foreach (var error in emailValidator.Errors)
            {
                OnError?.Invoke(sender, error.ToString());
            }

            return;
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}
