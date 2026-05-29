// Name: PCSX2 Texture Replacement Alpha Fixer
// Submenu: Advanced
// Author: Enignmeman
// Version: 2.1
// Desc: Fixes image's Alpha for PCSX2 texture pack usage
// Keywords: PS2
// Title: PCSX2 Texture Replacement Alpha Fixer
// URL: https://github.com/Enignmeman/Alpha-management-tools
// Help: https://github.com/Enignmeman/Alpha-management-tools

// UI
#region UICode
RadioButtonControl advanced = 0; // Alpha values|0 to 127|0 or 128
LabelComment someUselessValue = "Some textures only have opaque or fully transparent colors (Alpha value at 128 or 0 respectively), and some textures have transparent colors with an Alpha value that ranges from 0 to 127."; // Texture type
#endregion

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

            if (advanced == 0){
                // turn pixel alpha to 8bit to 7bit (0 to 127)
                if (sourcePixel.A <= 1) sourcePixel.A = 0;
                else if (sourcePixel.A % 2 == 1) sourcePixel.A = (byte)((sourcePixel.A - 1) / 2);
                    else sourcePixel.A = (byte)(sourcePixel.A / 2);
                    }
                // turn pixel alpha to correct value (0 or 128)
                else {
                    if (sourcePixel.A > 0) sourcePixel.A = 128;
                    else{
                        sourcePixel.R = 0;
                        sourcePixel.G = 0;
                        sourcePixel.B = 0;
                    }
                }

                // Save your pixel to the output canvas
                outputRegion[x,y] = sourcePixel;
            }
        }
    }