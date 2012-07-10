using System;
using Gtk;
using System.Collections.Generic;

namespace localfiles
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class View : Gtk.Bin
	{
		//private List<String> filenames;
		
		public View ()
		{
			this.Build ();
			this.list.AppendColumn ("Files", new CellRendererText (), "text", 0);
			fillList();
		}

		protected void onAddClicked (object sender, System.EventArgs e)
		{
			String[] items = {};
			FileChooserDialog dialog = 
				new FileChooserDialog("Open",
				     null,
					FileChooserAction.Open,
					"Cancel",ResponseType.Cancel,
		            "Open",ResponseType.Accept);
			dialog.SelectMultiple=true;
			FileFilter filter = new FileFilter();
			/*filter.AddPattern("*.jpg");
			filter.AddPattern("*.jpeg");
			filter.AddPattern("*.png");
			filter.AddPattern("*.svg");*/
			filter.AddMimeType("image/*");
			dialog.Filter = filter;
			if(dialog.Run()==(int)ResponseType.Accept)
			{
				items = dialog.Filenames;
			}
			dialog.Destroy();
			localfiles.LocalFiles.addItems(items);
			fillList();
		}
		
		private void fillList()
		{
			TreeStore store = new TreeStore(typeof(String));
			foreach(String item in LocalFiles.filenames)
				store.AppendValues(item);
			this.list.Model = store;
			this.list.ShowAll();
		}
		
		protected void onClearClicked (object sender, System.EventArgs e)
		{
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(
				null,Gtk.DialogFlags.Modal,Gtk.MessageType.Question,
				Gtk.ButtonsType.YesNo,"Limpar lista?","");
			if(dialog.Run() == (int)ResponseType.Yes)
			{
				LocalFiles.filenames = new List<string>();
				fillList();
			}
			dialog.Destroy();
		}

		protected void OnRemoveClicked (object sender, System.EventArgs e)
		{
			TreeSelection sel = this.list.Selection;
			TreeModel model;
			TreeIter iter;
			sel.GetSelectedRows(out model);
			if(!sel.GetSelected(out iter))
				return;
			
			int index = model.GetPath(iter).Indices[0];
			//
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(
				null,Gtk.DialogFlags.Modal,Gtk.MessageType.Question,
				Gtk.ButtonsType.YesNo,"Remover \""+LocalFiles.filenames[index]+"\"?","");
			if(dialog.Run() == (int)ResponseType.Yes)
			{
				LocalFiles.filenames.RemoveAt(index);
				fillList();
			}
			dialog.Destroy();
			//
			
		}
		
		
	}
}

