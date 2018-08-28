using System;
using Networker.DefaultFormatter;

namespace Forza7DataClient
{
    /// <summary>
    /// CREDIT: https://github.com/mover5/Forza7DataOutMonitor/tree/master/Forza7Telemetry.Monitor/Telemetry
    /// </summary>
    public class DataOutPacket : DefaultNetworkerPacketBase
    {
        public int IsRaceOn { get; set; } // = 1 when race is on. = 0 when in menus/race stopped …
        public uint TimestampMS { get; set; } //Can overflow to 0 eventually
        public float EngineMaxRpm { get; set; }
        public float EngineIdleRpm { get; set; }
        public float CurrentEngineRpm { get; set; }
        public float AccelerationX { get; set; } //In the car's local space; X = right, Y = up, Z = forward
        public float AccelerationY { get; set; }
        public float AccelerationZ { get; set; }
        public float VelocityX { get; set; } //In the car's local space; X = right, Y = up, Z = forward
        public float VelocityY { get; set; }
        public float VelocityZ { get; set; }
        public float AngularVelocityX { get; set; } //In the car's local space; X = pitch, Y = yaw, Z = roll
        public float AngularVelocityY { get; set; }
        public float AngularVelocityZ { get; set; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public float Roll { get; set; }
        public float NormalizedSuspensionTravelFrontLeft { get; set; } // Suspension travel normalized: 0.0f = max stretch; 1.0 = max compression
        public float NormalizedSuspensionTravelFrontRight { get; set; }
        public float NormalizedSuspensionTravelRearLeft { get; set; }
        public float NormalizedSuspensionTravelRearRight { get; set; }
        public float TireSlipRatioFrontLeft { get; set; } // Tire normalized slip ratio, = 0 means 100% grip and |ratio| > 1.0 means loss of grip.
        public float TireSlipRatioFrontRight { get; set; }
        public float TireSlipRatioRearLeft { get; set; }
        public float TireSlipRatioRearRight { get; set; }
        public float WheelRotationSpeedFrontLeft { get; set; } // Wheel rotation speed radians/sec. 
        public float WheelRotationSpeedFrontRight { get; set; }
        public float WheelRotationSpeedRearLeft { get; set; }
        public float WheelRotationSpeedRearRight { get; set; }
        public int WheelOnRumbleStripFrontLeft { get; set; } // = 1 when wheel is on rumble strip, = 0 when off.
        public int WheelOnRumbleStripFrontRight { get; set; }
        public int WheelOnRumbleStripRearLeft { get; set; }
        public int WheelOnRumbleStripRearRight { get; set; }
        public float WheelInPuddleDepthFrontLeft { get; set; } // = from 0 to 1, where 1 is the deepest puddle
        public float WheelInPuddleDepthFrontRight { get; set; }
        public float WheelInPuddleDepthRearLeft { get; set; }
        public float WheelInPuddleDepthRearRight { get; set; }
        public float SurfaceRumbleFrontLeft { get; set; } // Non-dimensional surface rumble values passed to controller force feedback
        public float SurfaceRumbleFrontRight { get; set; }
        public float SurfaceRumbleRearLeft { get; set; }
        public float SurfaceRumbleRearRight { get; set; }
        public float TireSlipAngleFrontLeft { get; set; } // Tire normalized slip angle, = 0 means 100% grip and |angle| > 1.0 means loss of grip.
        public float TireSlipAngleFrontRight { get; set; }
        public float TireSlipAngleRearLeft { get; set; }
        public float TireSlipAngleRearRight { get; set; }
        public float TireCombinedSlipFrontLeft { get; set; } // Tire normalized combined slip, = 0 means 100% grip and |slip| > 1.0 means loss of grip.
        public float TireCombinedSlipFrontRight { get; set; }
        public float TireCombinedSlipRearLeft { get; set; }
        public float TireCombinedSlipRearRight { get; set; }
        public float SuspensionTravelMetersFrontLeft { get; set; } // Actual suspension travel in meters
        public float SuspensionTravelMetersFrontRight { get; set; }
        public float SuspensionTravelMetersRearLeft { get; set; }
        public float SuspensionTravelMetersRearRight { get; set; }
        public int CarOrdinal { get; set; } //Unique ID of the car make/model
        public int CarClass { get; set; } //Between 0 (D -- worst cars) and 7 (X class -- best cars) inclusive 
        public int CarPerformanceIndex { get; set; } //Between 100 (slowest car) and 999 (fastest car) inclusive
        public int DrivetrainType { get; set; } //Corresponds to EDrivetrainType; 0 = FWD, 1 = RWD, 2 = AWD
        public int NumCylinders { get; set; } //Number of cylinders in the engine

        public DataOutPacket(byte[] packetBytes) : base(packetBytes)
        {
            this.IsRaceOn = BitConverter.ToInt32(packetBytes, 0);
            this.TimestampMS = BitConverter.ToUInt32(packetBytes, 4);
            this.EngineMaxRpm = BitConverter.ToSingle(packetBytes, 8);
            this.EngineIdleRpm = BitConverter.ToSingle(packetBytes, 12);
            this.CurrentEngineRpm = BitConverter.ToSingle(packetBytes, 16);
            this.AccelerationX = BitConverter.ToSingle(packetBytes, 20);
            this.AccelerationY = BitConverter.ToSingle(packetBytes, 24);
            this.AccelerationZ = BitConverter.ToSingle(packetBytes, 28);
            this.VelocityX = BitConverter.ToSingle(packetBytes, 32);
            this.VelocityY = BitConverter.ToSingle(packetBytes, 36);
            this.VelocityZ = BitConverter.ToSingle(packetBytes, 40);
            this.AngularVelocityX = BitConverter.ToSingle(packetBytes, 44);
            this.AngularVelocityY = BitConverter.ToSingle(packetBytes, 48);
            this.AngularVelocityZ = BitConverter.ToSingle(packetBytes, 52);
            this.Yaw = BitConverter.ToSingle(packetBytes, 56);
            this.Pitch = BitConverter.ToSingle(packetBytes, 60);
            this.Roll = BitConverter.ToSingle(packetBytes, 64);
            this.NormalizedSuspensionTravelFrontLeft = BitConverter.ToSingle(packetBytes, 68);
            this.NormalizedSuspensionTravelFrontRight = BitConverter.ToSingle(packetBytes, 72);
            this.NormalizedSuspensionTravelRearLeft = BitConverter.ToSingle(packetBytes, 76);
            this.NormalizedSuspensionTravelRearRight = BitConverter.ToSingle(packetBytes, 80);
            this.TireSlipRatioFrontLeft = BitConverter.ToSingle(packetBytes, 84);
            this.TireSlipRatioFrontRight = BitConverter.ToSingle(packetBytes, 88);
            this.TireSlipRatioRearLeft = BitConverter.ToSingle(packetBytes, 92);
            this.TireSlipRatioRearRight = BitConverter.ToSingle(packetBytes, 96);
            this.WheelRotationSpeedFrontLeft = BitConverter.ToSingle(packetBytes, 100);
            this.WheelRotationSpeedFrontRight = BitConverter.ToSingle(packetBytes, 104);
            this.WheelRotationSpeedRearLeft = BitConverter.ToSingle(packetBytes, 108);
            this.WheelRotationSpeedRearRight = BitConverter.ToSingle(packetBytes, 112);
            this.WheelOnRumbleStripFrontLeft = BitConverter.ToInt32(packetBytes, 116);
            this.WheelOnRumbleStripFrontRight = BitConverter.ToInt32(packetBytes, 120);
            this.WheelOnRumbleStripRearLeft = BitConverter.ToInt32(packetBytes, 124);
            this.WheelOnRumbleStripRearRight = BitConverter.ToInt32(packetBytes, 128);
            this.WheelInPuddleDepthFrontLeft = BitConverter.ToSingle(packetBytes, 132);
            this.WheelInPuddleDepthFrontRight = BitConverter.ToSingle(packetBytes, 136);
            this.WheelInPuddleDepthRearLeft = BitConverter.ToSingle(packetBytes, 140);
            this.WheelInPuddleDepthRearRight = BitConverter.ToSingle(packetBytes, 144);
            this.SurfaceRumbleFrontLeft = BitConverter.ToSingle(packetBytes, 148);
            this.SurfaceRumbleFrontRight = BitConverter.ToSingle(packetBytes, 152);
            this.SurfaceRumbleRearLeft = BitConverter.ToSingle(packetBytes, 156);
            this.SurfaceRumbleRearRight = BitConverter.ToSingle(packetBytes, 160);
            this.TireSlipAngleFrontLeft = BitConverter.ToSingle(packetBytes, 164);
            this.TireSlipAngleFrontRight = BitConverter.ToSingle(packetBytes, 168);
            this.TireSlipAngleRearLeft = BitConverter.ToSingle(packetBytes, 172);
            this.TireSlipAngleRearRight = BitConverter.ToSingle(packetBytes, 176);
            this.TireCombinedSlipFrontLeft = BitConverter.ToSingle(packetBytes, 180);
            this.TireCombinedSlipFrontRight = BitConverter.ToSingle(packetBytes, 184);
            this.TireCombinedSlipRearLeft = BitConverter.ToSingle(packetBytes, 188);
            this.TireCombinedSlipRearRight = BitConverter.ToSingle(packetBytes, 192);
            this.SuspensionTravelMetersFrontLeft = BitConverter.ToSingle(packetBytes, 196);
            this.SuspensionTravelMetersFrontRight = BitConverter.ToSingle(packetBytes, 200);
            this.SuspensionTravelMetersRearLeft = BitConverter.ToSingle(packetBytes, 204);
            this.SuspensionTravelMetersRearRight = BitConverter.ToSingle(packetBytes, 208);
            this.CarOrdinal = BitConverter.ToInt32(packetBytes, 212);
            this.CarClass = BitConverter.ToInt32(packetBytes, 216);
            this.CarPerformanceIndex = BitConverter.ToInt32(packetBytes, 220);
            this.DrivetrainType = BitConverter.ToInt32(packetBytes, 224);
            this.NumCylinders = BitConverter.ToInt32(packetBytes, 228);
        }
    }
}