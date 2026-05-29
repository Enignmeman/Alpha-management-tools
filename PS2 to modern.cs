// Name: PCSX2 Dumped Texture Alpha Fixer
// Submenu: Advanced
// Author: Enignmeman
// Version: 1.2
// Desc: Fixes PCSX2 dumped textures' Alpha for most usages
// Keywords: PS2
// URL: https://github.com/Enignmeman/Alpha-management-tools
// Help: https://github.com/Enignmeman/Alpha-management-tools

protected override void OnRender(IBitmapEffectOutput output)
{
    using IEffectInputBitmap<ColorBgra32> sourceBitmap = Environment.GetSourceBitmapBgra32();
    using IBitmapLock<ColorBgra32> sourceLock = Environment.GetSourceBitmapBgra32().Lock(new RectInt32(0, 0, sourceBitmap.Size));
    RegionPtr<ColorBgra32> sourceRegion = sourceLock.AsRegionPtr();

    RectInt32 outputBounds = output.Bounds;
    using IBitmapLock<ColorBgra32> outputLock = output.LockBgra32();
    RegionPtr<ColorBgra32> outputSubRegion = outputLock.AsRegionPtr();
    var outputRegion = outputSubRegion.OffsetView(-outputBounds.Location);

    // Loop through the output canvas tile
    for (int y = outputBounds.Top; y < outputBounds.Bottom; ++y)
    {
        if (IsCancelRequested) return;

        for (int x = outputBounds.Left; x < outputBounds.Right; ++x)
        {
            // Get your source pixel
            ColorBgra32 sourcePixel = sourceRegion[x,y];

            // turn pixel alpha to 7bit to 8bit
            if (sourcePixel.A >= 128) sourcePixel.A = 255;
            else sourcePixel.A = (byte)(sourcePixel.A * 2 + 1);

            // Save your pixel to the output canvas
            outputRegion[x,y] = sourcePixel;
        }
    }
}