//////////////////////////////////////////////////////
// MK Glow Camera Data PPSV2	    	    	    //
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Glow.LWRP
{
    internal class CameraDataPPSv2 : CameraData
    {
        public static implicit operator CameraDataPPSv2(UnityEngine.Camera input)
        {
            CameraDataPPSv2 data = new CameraDataPPSv2();

            data.width = input.pixelWidth;
            data.height = input.pixelHeight;
            data.stereoEnabled = input.stereoEnabled;
            data.aspect = input.aspect;
            data.worldToCameraMatrix = input.worldToCameraMatrix;
            
            return data;
        }
    }
}
