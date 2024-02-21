// Decompiled with JetBrains decompiler
// Type: CustomWeaponSpeed.WeaponPackAlphaMod
// Assembly: CustomWeaponSpeed, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E9E3A31-DC48-4478-B20D-6EF78C63E39C
// Assembly location: D:\Develope\VintageStory\Temp\WeaponPackAlpha\CustomWeaponSpeed.dll

using Vintagestory.API.Common;

namespace CustomWeaponSpeed
{
  public class WeaponPackAlphaMod : ModSystem
  {
    public override void Start(ICoreAPI api)
    {
            api.RegisterItemClass("VerySlowSwordChargeFast", typeof(VerySlowSwordChargeFast));
            api.RegisterItemClass("VerySlowSpearChargeSlow", typeof(VerySlowSpearChargeSlow));
            api.RegisterItemClass("SlowSwordChargeSlow", typeof(SlowSwordChargeSlow));
            api.RegisterItemClass("SlowSwordChargeFast", typeof(SlowSwordChargeFast));
            api.RegisterItemClass("SlowSpearChargeFast", typeof(SlowSpearChargeFast));
            api.RegisterItemClass("NormalSwordChargeNone", typeof(NormalSwordChargeNone));
            api.RegisterItemClass("NormalSwordChargeFast", typeof(NormalSwordChargeFast));
            api.RegisterItemClass("FastSwordChargeNone", typeof(FastSwordChargeNone));
            api.RegisterItemClass("VeryFastSwordChargeNone", typeof(VeryFastSwordChargeNone));
            api.RegisterItemClass("VeryFastSpearChargeNone", typeof(VeryFastSpearChargeNone));
        }
  }
}
