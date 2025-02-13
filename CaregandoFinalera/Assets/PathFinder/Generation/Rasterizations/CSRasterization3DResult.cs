﻿using K_PathFinder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace K_PathFinder.Rasterization {
    public class CSRasterization3DResult {
        public readonly Voxel3D[] voxels;
        public readonly int voxelsX, voxelsY, volumeStartX, volumeStartZ, volumeSizeX, volumeSizeZ;

        public CSRasterization3DResult(Voxel3D[] voxels, int voxelsX, int voxelsY, int volumeStartX, int volumeStartZ, int volumeSizeX, int volumeSizeZ) {
            this.voxels = voxels;
            this.voxelsX = voxelsX;
            this.voxelsY = voxelsY;
            this.volumeStartX = volumeStartX;
            this.volumeStartZ = volumeStartZ;
            this.volumeSizeX = volumeSizeX;
            this.volumeSizeZ = volumeSizeZ;
        }

        public void Read(Volume volume, Area area) {
            if (area.id == 1) {//clear area
                for (int x = 0; x < volumeSizeX; x++) {
                    for (int z = 0; z < volumeSizeZ; z++) {
                        var curVoxel = voxels[x + (z * voxelsX)];

                        if (curVoxel.exist) {
                            volume.OverrideVoxel(volumeStartX + x, volumeStartZ + z, curVoxel.max, curVoxel.min, area, (int)Passability.Unwalkable);
                        }
                    }
                }
            }
            else {
                for (int x = 0; x < volumeSizeX; x++) {
                    for (int z = 0; z < volumeSizeZ; z++) {
                        var curVoxel = voxels[x + (z * voxelsX)];

                        if (curVoxel.exist) {
                            volume.OverrideVoxel(volumeStartX + x, volumeStartZ + z, curVoxel.max, curVoxel.min, area, curVoxel.passability);
                        }
                    }
                }
            }

        }
    }
}