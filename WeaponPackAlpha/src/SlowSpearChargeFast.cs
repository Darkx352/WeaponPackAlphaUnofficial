// Decompiled with JetBrains decompiler
// Type: CustomWeaponSpeed.SlowSpearChargeFast
// Assembly: CustomWeaponSpeed, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E9E3A31-DC48-4478-B20D-6EF78C63E39C
// Assembly location: D:\Develope\VintageStory\Temp\WeaponPackAlpha\CustomWeaponSpeed.dll

using System;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;

namespace CustomWeaponSpeed
{
  internal class SlowSpearChargeFast : Item
  {
    public override string GetHeldTpUseAnimation(ItemSlot activeHotbarSlot, Entity byEntity) => (string) null;

    public override bool OnHeldInteractStep(
      float secondsUsed,
      ItemSlot slot,
      EntityAgent byEntity,
      BlockSelection blockSel,
      EntitySelection entitySel)
    {
      if (byEntity.World is IClientWorldAccessor)
      {
        ModelTransform modelTransform = new ModelTransform();
        modelTransform.EnsureDefaultValues();
        float num = GameMath.Clamp(secondsUsed * 4f, 0.0f, 2f);
        modelTransform.Translation.Set((float) (-(double) num / 3.0), 0.0f, num / 3f);
        modelTransform.Rotation.Set(0.0f, (float) (-(double) num * 15.0), 0.0f);
        byEntity.Controls.UsingHeldItemTransformBefore = modelTransform;
      }
      return true;
    }

    public override void OnHeldAttackStart(
      ItemSlot slot,
      EntityAgent byEntity,
      BlockSelection blockSel,
      EntitySelection entitySel,
      ref EnumHandHandling handling)
    {
      byEntity.Attributes.SetInt("didattack", 0);
      byEntity.World.RegisterCallback((Action<float>) (dt =>
      {
        IPlayer player = (byEntity as EntityPlayer).Player;
        if (player == null || byEntity.Controls.HandUse != EnumHandInteract.HeldItemAttack)
          return;
        player.Entity.World.PlaySoundAt(new AssetLocation("sounds/player/strike"), (Entity) player.Entity, player, (float) (0.89999997615814209 + this.api.World.Rand.NextDouble() * 0.20000000298023224), 16f, 0.5f);
      }), 200);
      handling = EnumHandHandling.PreventDefault;
    }

    public override bool OnHeldAttackStep(
      float secondsPassed,
      ItemSlot slot,
      EntityAgent byEntity,
      BlockSelection blockSelection,
      EntitySelection entitySel)
    {
      float num1 = -Math.Min(0.8f, 3f * secondsPassed);
      float num2 = Math.Min(1.2f, 20f * Math.Max(0.0f, secondsPassed - 0.2f));
      if (byEntity.World.Side == EnumAppSide.Client)
      {
        IClientWorldAccessor world = byEntity.World as IClientWorldAccessor;
        ModelTransform modelTransform = new ModelTransform();
        modelTransform.EnsureDefaultValues();
        float num3 = num2 + num1;
        float num4 = Math.Min(0.2f, 1.5f * secondsPassed);
        float num5 = Math.Max(0.0f, (float) (2.0 * ((double) secondsPassed - 1.0)));
        if ((double) secondsPassed > 0.40000000596046448)
          num3 = Math.Max(0.0f, num3 - num5);
        float num6 = Math.Max(0.0f, num4 - num5);
        modelTransform.Translation.Set(-1f * num3, num6 * 0.4f, (float) (-(double) num3 * 0.800000011920929 * 2.5999999046325684));
        modelTransform.Rotation.Set((float) (-(double) num3 * 9.0), num3 * 30f, (float) (-(double) num3 * 30.0));
        byEntity.Controls.UsingHeldItemTransformAfter = modelTransform;
        if ((double) num2 > 1.1499999761581421 && byEntity.Attributes.GetInt("didattack", 0) == 0)
        {
          world.TryAttackEntity(entitySel);
          byEntity.Attributes.SetInt("didattack", 1);
          world.AddCameraShake(0.2f);
        }
      }
      return secondsPassed < 1.3500000238418579 * 0.85; // polespear
    }

    public override void OnHeldAttackStop(
      float secondsPassed,
      ItemSlot slot,
      EntityAgent byEntity,
      BlockSelection blockSelection,
      EntitySelection entitySel)
    {
    }
  }
}
