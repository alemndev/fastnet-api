﻿using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class Attention
{
    public int Attentionid { get; set; }

    public int TurnTurnid { get; set; }

    public int? ClientClientid { get; set; }

    public int AttentiontypeAttentiontypeid { get; set; }

    public int AttentionstatusStatusid { get; set; }

    public virtual Attentionstatus AttentionstatusStatus { get; set; } = null!;

    public virtual Attentiontype AttentiontypeAttentiontype { get; set; } = null!;

    public virtual Turn TurnTurn { get; set; } = null!;
}
