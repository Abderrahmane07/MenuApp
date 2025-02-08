using Microsoft.AspNetCore.Components;
using QRCoder;

namespace MenuApp.Services
{
	public interface IQrCodeService
	{
		string GenerateQRCodeForMenu(int restaurantId);
	}

	public class QrCodeService : IQrCodeService
	{
		private readonly NavigationManager _navigationManager;

		public QrCodeService(NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
		}

		public string GenerateQRCodeForMenu(int restaurantId)
		{
			string menuUrl = _navigationManager.ToAbsoluteUri($"/menu/{restaurantId}").ToString();

			using var qrGenerator = new QRCodeGenerator();
			var qrCodeData = qrGenerator.CreateQrCode(menuUrl, QRCodeGenerator.ECCLevel.Q);
			var qrCode = new BitmapByteQRCode(qrCodeData);
			var qrCodeImage = qrCode.GetGraphic(20);

			// Convert to base64 string for display in HTML
			return $"data:image/png;base64,{Convert.ToBase64String(qrCodeImage)}";
		}
	}
}
