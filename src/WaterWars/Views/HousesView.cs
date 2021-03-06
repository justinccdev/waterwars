/*
 * Copyright (2011) Intel Corporation and Sandia Corporation. Under the
 * terms of Contract DE-AC04-94AL85000 with Sandia Corporation, the
 * U.S. Government retains certain rights in this software.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 
 * -- Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * -- Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * -- Neither the name of the Intel Corporation nor the names of its
 *    contributors may be used to endorse or promote products derived from
 *    this software without specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 * PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL THE INTEL OR ITS
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
 * EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
 * PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
 * PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 * LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 */

using System.Collections.Generic;
using System.Reflection;
using log4net;
using OpenMetaverse;
using OpenSim.Region.Framework.Scenes;
using WaterWars.Models;
using WaterWars.Views.Widgets;
using WaterWars.Views.Widgets.Behaviours;

namespace WaterWars.Views
{        
    public class HousesView : GameAssetView
    {
//        private static readonly ILog m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public const string IN_WORLD_NAME = "Condo";

        public HousesView(WaterWarsController controller, Scene scene, AbstractGameAsset asset, AbstractView itemStoreView) 
            : base(controller, scene, asset, itemStoreView) 
        {
            m_veSceneObjectNames = new string[4, 2];             
            m_veSceneObjectNames[1, 0] = string.Format("{0}_Level-1-under-construction", IN_WORLD_NAME);
            m_veSceneObjectNames[2, 0] = string.Format("{0}_Level-2-under-construction", IN_WORLD_NAME);
            m_veSceneObjectNames[3, 0] = string.Format("{0}_Level-3-under-construction", IN_WORLD_NAME);            
            m_veSceneObjectNames[1, 1] = string.Format("{0}_Level-1", IN_WORLD_NAME);
            m_veSceneObjectNames[2, 1] = string.Format("{0}_Level-2", IN_WORLD_NAME);
            m_veSceneObjectNames[3, 1] = string.Format("{0}_Level-3", IN_WORLD_NAME);            
        }

        protected override void RegisterPart(SceneObjectPart part)
        {
            if (part.Name.StartsWith(IN_WORLD_NAME))
                m_button = new GameAssetButton(m_controller, part, this);
        }
    }
}