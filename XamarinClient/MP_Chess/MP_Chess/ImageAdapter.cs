using System;

using Android.Content;

using Android.Views;
using Android.Widget;

using Java;

namespace MP_Chess
{
	public class ImageAdapter : BaseAdapter
	{
		Context context;

		public ImageAdapter (Context c)
		{
			context = c;
		}

		public override int Count {
			get { return thumbIds.Length; }
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId (int position)
		{
			return 0;
		}

		// create a new ImageView for each item referenced by the Adapter
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View squareContainerView = convertView;
			ImageView imageView;
			if ( convertView == null ) {
				//Inflate the layout
				//LayoutInflater layoutInflater = this.context.GetLayoutInflater();
				LayoutInflater layoutInflater = LayoutInflater.From(context);
				squareContainerView = layoutInflater.Inflate(Resource.Layout.square, null);
			}

			if (convertView == null) {  // if it's not recycled, initialize some attributes
				imageView = new ImageView (context);
				imageView.LayoutParameters = new GridView.LayoutParams (100, 100);
				imageView.SetScaleType (ImageView.ScaleType.CenterCrop);
				//imageView.SetPadding (8, 8, 8, 8);
			} else {
				imageView = (ImageView)convertView;
			}

			imageView.SetImageResource (thumbIds[position]);
				//squareContainerView = new ImageView (context);
			if (position % 2 == 0) { //mock test
				// Add The piece
				ImageView pieceView = new ImageView(context);
				pieceView = (new ImageView(context)).FindViewById<ImageView> (Resource.Id.piece);
				pieceView.SetImageResource(Resource.Drawable.sample_0);
				//pieceView.SetTag(position);
			}

			return imageView;
			/**
			View squareContainerView = convertView;

			if ( convertView == null ) {
				//Inflate the layout
				LayoutInflater layoutInflater = LayoutInflater.From(context); //Instead of the line below
				//LayoutInflater layoutInflater = this.context.GetLayoutInflater();
				//squareContainerView = LayoutInflater.Inflate(Resource.Layout.square, null);
				LayoutInflater inflater =    (LayoutInflater)Context.GetSystemService(context.LayoutInflaterService);
				squareContainerView = inflater.Inflate (Resource.Layout.square, null);

				// Background
				ImageView squareView = (ImageView)squareContainerView.FindViewById<ImageView>(Resource.Id.square_background);
				//squareView.SetImageResource(this.aSquareImg[(position + position/8)%2]);
				squareView.SetImageResource(Resource.Drawable.grey);

				if (pPosition % 2 == 0) { //mock test
					// Add The piece
					ImageView pieceView = (ImageView)squareContainerView.findViewById(R.id.piece);
					pieceView.setImageResource(R.drawable.green);
					pieceView.setTag(position);
				}
			}
			return squareContainerView;**/
		}

		// references to our images
		/**
		int[] thumbIds = {
			Resource.Drawable.sample_2, Resource.Drawable.sample_3,
			Resource.Drawable.sample_4, Resource.Drawable.sample_5,
			Resource.Drawable.sample_6, Resource.Drawable.sample_7,
			Resource.Drawable.sample_0, Resource.Drawable.sample_1,
			Resource.Drawable.sample_2, Resource.Drawable.sample_3,
			Resource.Drawable.sample_4, Resource.Drawable.sample_5,
			Resource.Drawable.sample_6, Resource.Drawable.sample_7,
			Resource.Drawable.sample_0, Resource.Drawable.sample_1,
			Resource.Drawable.sample_2, Resource.Drawable.sample_3,
			Resource.Drawable.sample_4, Resource.Drawable.sample_5,
			Resource.Drawable.sample_6, Resource.Drawable.sample_7
		};
		*/
		int[] thumbIds = {
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.grey, Resource.Drawable.green,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey,
			Resource.Drawable.green, Resource.Drawable.grey

		};
	}
}

