﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace N3DSCmbViewer.Cmb
{
    [System.Diagnostics.DebuggerDisplay("{GetType()}")]
    class MatsChunk : BaseCTRChunk
    {
        // "Materials"?
        public override string ChunkTag { get { return "mats"; } }

        public uint MaterialCount { get; private set; }

        public Material[] Materials { get; private set; }
        public TexEnvStuff[] TexEnvStuffs { get; private set; }

        public MatsChunk(byte[] data, int offset, BaseCTRChunk parent)
            : base(data, offset, parent)
        {
            MaterialCount = BitConverter.ToUInt32(ChunkData, 0x8);

            int matDataSize = (BaseCTRChunk.IsMajora3D ? Material.DataSize_MM : Material.DataSize_OoT);

            Materials = new Material[MaterialCount];
            for (int i = 0; i < Materials.Length; i++) Materials[i] = new Material(ChunkData, 0xC + (i * matDataSize));

            TexEnvStuffs = new TexEnvStuff[MaterialCount];
            for (int i = 0; i < TexEnvStuffs.Length; i++) TexEnvStuffs[i] = new TexEnvStuff(ChunkData, 0xC + (int)(MaterialCount * matDataSize) + (i * TexEnvStuff.DataSize));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("-- {0} --\n", this.GetType().Name);
            sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Number of materials: 0x{0:X}\n", MaterialCount);
            sb.AppendLine();

            foreach (Material material in Materials) sb.Append(material.ToString());

            return sb.ToString();
        }

        [System.Diagnostics.DebuggerDisplay("{GetType()}")]
        public class Material
        {
            public const int DataSize_OoT = 0x15C;
            public const int DataSize_MM = 0x16C;

            public short[] TextureIDs { get; private set; }
            public TextureMinFilter[] TextureMinFilters { get; private set; }
            public TextureMagFilter[] TextureMagFilters { get; private set; }
            public TextureWrapMode[] TextureWrapModeSs { get; private set; }
            public TextureWrapMode[] TextureWrapModeTs { get; private set; }

            public uint Unknown000 { get; private set; }
            public uint Unknown004 { get; private set; }
            public uint Unknown008 { get; private set; }
            public uint Unknown00C { get; private set; }
            //Texture ID 0
            public ushort Unknown012 { get; private set; }
            //MinFilter 0
            //MagFilter 0
            //WrapModeS 0
            //WrapModeT 0
            public uint Unknown01C { get; private set; }
            public uint Unknown020 { get; private set; }
            public uint Unknown024 { get; private set; }
            //Texture ID 1
            public ushort Unknown02A { get; private set; }
            //MinFilter 1
            //MagFilter 1
            //WrapModeS 1
            //WrapModeT 1
            public uint Unknown034 { get; private set; }
            public uint Unknown038 { get; private set; }
            public uint Unknown03C { get; private set; }
            //Texture ID 2
            public ushort Unknown042 { get; private set; }
            //MinFilter 2
            //MagFilter 2
            //WrapModeS 2
            //WrapModeT 2
            public uint Unknown04C { get; private set; }
            public uint Unknown050 { get; private set; }
            public uint Unknown054 { get; private set; }
            public uint Unknown058 { get; private set; }
            public float Float05C { get; private set; }
            public float Float060 { get; private set; }
            public uint Unknown064 { get; private set; }
            public uint Unknown068 { get; private set; }
            public uint Unknown06C { get; private set; }
            public uint Unknown070 { get; private set; }
            public float Float074 { get; private set; }
            public float Float078 { get; private set; }
            public uint Unknown07C { get; private set; }
            public uint Unknown080 { get; private set; }
            public uint Unknown084 { get; private set; }
            public uint Unknown088 { get; private set; }
            public float Float08C { get; private set; }
            public float Float090 { get; private set; }
            public uint Unknown094 { get; private set; }
            public uint Unknown098 { get; private set; }
            public uint Unknown09C { get; private set; }
            public uint Unknown0A0 { get; private set; }
            public uint Unknown0A4 { get; private set; }    //00FFFFFF
            public uint Unknown0A8 { get; private set; }    //FFFFFFFF
            public uint Unknown0AC { get; private set; }    //007F7F7F
            public uint Unknown0B0 { get; private set; }
            public uint Unknown0B4 { get; private set; }    //FF000000
            public uint Unknown0B8 { get; private set; }    //FF000000
            public uint Unknown0BC { get; private set; }    //FF000000
            public uint Unknown0C0 { get; private set; }    //FF000000
            public uint Unknown0C4 { get; private set; }    //FF000000
            public uint Unknown0C8 { get; private set; }    //FF000000
            public uint Unknown0CC { get; private set; }
            public uint Unknown0D0 { get; private set; }
            public uint Unknown0D4 { get; private set; }
            public float Float0D8 { get; private set; }
            public uint Unknown0DC { get; private set; }    //62C884C0
            public uint Unknown0E0 { get; private set; }
            public uint Unknown0E4 { get; private set; }    //000062B0
            public uint Unknown0E8 { get; private set; }    //000062C0
            public uint Unknown0EC { get; private set; }
            public uint Unknown0F0 { get; private set; }    //62A0FF01
            public float Float0F4 { get; private set; }
            public uint Unknown0F8 { get; private set; }    //62A0FF01
            public float Float0FC { get; private set; }
            public uint Unknown100 { get; private set; }    //62A0FF01
            public float Float104 { get; private set; }
            public uint Unknown108 { get; private set; }    //62A0FF01
            public float Float10C { get; private set; }
            public uint Unknown110 { get; private set; }    //62A0FF01
            public float Float114 { get; private set; }
            public uint Unknown118 { get; private set; }    //62A0FF01
            public float Float11C { get; private set; }
            public uint NumberOfIndicesToUnknown { get; private set; }    //00000001
            public ushort[] IndicesToUnknown { get; private set; }
            public ushort MaybeAlphaUnknown130 { get; private set; }            //0000
            public AlphaFunction MaybeAlphaFunction { get; private set; }       //0207
            public ushort MaybeStencilUnknown134 { get; private set; }          //0101
            public StencilFunction MaybeStencilFunction { get; private set; }   //0201
            public uint Unknown138 { get; private set; }
            public BlendingFactorSrc BlendingFactorSrc { get; private set; }    //0303
            public BlendingFactorDest BlendingFactorDest { get; private set; }    //0302
            public uint Unknown140 { get; private set; }    //00008006
            public uint Unknown144 { get; private set; }    //00000001
            public uint Unknown148 { get; private set; }    //00008006
            public uint Unknown14C { get; private set; }
            public uint Unknown150 { get; private set; }
            public uint Unknown154 { get; private set; }
            public float Float158 { get; private set; }

            //MM3D
            public ushort Unknown15C { get; private set; }
            public ushort Unknown15E { get; private set; }
            public ushort Unknown160 { get; private set; }
            public ushort Unknown162 { get; private set; }
            public ushort Unknown164 { get; private set; }
            public ushort Unknown166 { get; private set; }
            public uint Unknown168 { get; private set; }

            public Material(byte[] data, int offset)
            {
                TextureIDs = new short[3];
                TextureMinFilters = new TextureMinFilter[3];
                TextureMagFilters = new TextureMagFilter[3];
                TextureWrapModeSs = new TextureWrapMode[3];
                TextureWrapModeTs = new TextureWrapMode[3];

                Unknown000 = BitConverter.ToUInt32(data, offset);
                Unknown004 = BitConverter.ToUInt32(data, offset + 0x004);
                Unknown008 = BitConverter.ToUInt32(data, offset + 0x008);
                Unknown00C = BitConverter.ToUInt32(data, offset + 0x00C);
                TextureIDs[0] = BitConverter.ToInt16(data, offset + 0x010);
                Unknown012 = BitConverter.ToUInt16(data, offset + 0x012);
                TextureMinFilters[0] = (TextureMinFilter)BitConverter.ToUInt16(data, offset + 0x014);
                TextureMagFilters[0] = (TextureMagFilter)BitConverter.ToUInt16(data, offset + 0x016);
                TextureWrapModeSs[0] = (TextureWrapMode)BitConverter.ToUInt16(data, offset + 0x018);
                TextureWrapModeTs[0] = (TextureWrapMode)BitConverter.ToUInt16(data, offset + 0x01A);
                Unknown01C = BitConverter.ToUInt32(data, offset + 0x01C);
                Unknown020 = BitConverter.ToUInt32(data, offset + 0x020);
                Unknown024 = BitConverter.ToUInt32(data, offset + 0x024);
                TextureIDs[1] = BitConverter.ToInt16(data, offset + 0x028);
                Unknown02A = BitConverter.ToUInt16(data, offset + 0x02A);
                TextureMinFilters[1] = (TextureMinFilter)BitConverter.ToUInt16(data, offset + 0x02C);
                TextureMagFilters[1] = (TextureMagFilter)BitConverter.ToUInt16(data, offset + 0x02E);
                TextureWrapModeSs[1] = (TextureWrapMode)BitConverter.ToUInt16(data, offset + 0x030);
                TextureWrapModeTs[1] = (TextureWrapMode)BitConverter.ToUInt16(data, offset + 0x032);
                Unknown034 = BitConverter.ToUInt32(data, offset + 0x034);
                Unknown038 = BitConverter.ToUInt32(data, offset + 0x038);
                Unknown03C = BitConverter.ToUInt32(data, offset + 0x03C);
                TextureIDs[2] = BitConverter.ToInt16(data, offset + 0x040);
                Unknown042 = BitConverter.ToUInt16(data, offset + 0x042);
                TextureMinFilters[2] = (TextureMinFilter)BitConverter.ToUInt16(data, offset + 0x044);
                TextureMagFilters[2] = (TextureMagFilter)BitConverter.ToUInt16(data, offset + 0x046);
                TextureWrapModeSs[2] = (TextureWrapMode)BitConverter.ToUInt16(data, offset + 0x048);
                TextureWrapModeTs[2] = (TextureWrapMode)BitConverter.ToUInt16(data, offset + 0x04A);
                Unknown04C = BitConverter.ToUInt32(data, offset + 0x04C);
                Unknown050 = BitConverter.ToUInt32(data, offset + 0x050);
                Unknown054 = BitConverter.ToUInt32(data, offset + 0x054);
                Unknown058 = BitConverter.ToUInt32(data, offset + 0x058);
                Float05C = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x05C)), 0);
                Float060 = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x060)), 0);
                Unknown064 = BitConverter.ToUInt32(data, offset + 0x064);
                Unknown068 = BitConverter.ToUInt32(data, offset + 0x068);
                Unknown06C = BitConverter.ToUInt32(data, offset + 0x06C);
                Unknown070 = BitConverter.ToUInt32(data, offset + 0x070);
                Float074 = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x074)), 0);
                Float078 = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x078)), 0);
                Unknown07C = BitConverter.ToUInt32(data, offset + 0x07C);
                Unknown080 = BitConverter.ToUInt32(data, offset + 0x080);
                Unknown084 = BitConverter.ToUInt32(data, offset + 0x084);
                Unknown088 = BitConverter.ToUInt32(data, offset + 0x088);
                Float08C = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x08C)), 0);
                Float090 = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x090)), 0);
                Unknown094 = BitConverter.ToUInt32(data, offset + 0x094);
                Unknown098 = BitConverter.ToUInt32(data, offset + 0x098);
                Unknown09C = BitConverter.ToUInt32(data, offset + 0x09C);
                Unknown0A0 = BitConverter.ToUInt32(data, offset + 0x0A0);
                Unknown0A4 = BitConverter.ToUInt32(data, offset + 0x0A4);
                Unknown0A8 = BitConverter.ToUInt32(data, offset + 0x0A8);
                Unknown0AC = BitConverter.ToUInt32(data, offset + 0x0AC);
                Unknown0B0 = BitConverter.ToUInt32(data, offset + 0x0B0);
                Unknown0B4 = BitConverter.ToUInt32(data, offset + 0x0B4);
                Unknown0B8 = BitConverter.ToUInt32(data, offset + 0x0B8);
                Unknown0BC = BitConverter.ToUInt32(data, offset + 0x0BC);
                Unknown0C0 = BitConverter.ToUInt32(data, offset + 0x0C0);
                Unknown0C4 = BitConverter.ToUInt32(data, offset + 0x0C4);
                Unknown0C8 = BitConverter.ToUInt32(data, offset + 0x0C8);
                Unknown0CC = BitConverter.ToUInt32(data, offset + 0x0CC);
                Unknown0D0 = BitConverter.ToUInt32(data, offset + 0x0D0);
                Unknown0D4 = BitConverter.ToUInt32(data, offset + 0x0D4);
                Float0D8 = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x0D8)), 0);
                Unknown0F0 = BitConverter.ToUInt32(data, offset + 0x0F0);
                Float0F4 = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x0F4)), 0);
                Unknown0F8 = BitConverter.ToUInt32(data, offset + 0x0F8);
                Float0FC = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x0FC)), 0);
                Unknown100 = BitConverter.ToUInt32(data, offset + 0x100);
                Float104 = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x104)), 0);
                Unknown108 = BitConverter.ToUInt32(data, offset + 0x108);
                Float10C = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x10C)), 0);
                Unknown110 = BitConverter.ToUInt32(data, offset + 0x110);
                Float114 = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x114)), 0);
                Unknown118 = BitConverter.ToUInt32(data, offset + 0x118);
                Float11C = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x11C)), 0);
                NumberOfIndicesToUnknown = BitConverter.ToUInt32(data, offset + 0x120);
                IndicesToUnknown = new ushort[NumberOfIndicesToUnknown];
                for (int i = 0; i < IndicesToUnknown.Length; i++) IndicesToUnknown[i] = BitConverter.ToUInt16(data, offset + 0x124 + (i * sizeof(ushort)));
                MaybeAlphaUnknown130 = BitConverter.ToUInt16(data, offset + 0x130);
                MaybeAlphaFunction = (AlphaFunction)BitConverter.ToUInt16(data, offset + 0x132);
                MaybeStencilUnknown134 = BitConverter.ToUInt16(data, offset + 0x134);
                MaybeStencilFunction = (StencilFunction)BitConverter.ToUInt16(data, offset + 0x136);
                Unknown138 = BitConverter.ToUInt32(data, offset + 0x138);
                BlendingFactorSrc = (BlendingFactorSrc)BitConverter.ToUInt16(data, offset + 0x13C);
                BlendingFactorDest = (BlendingFactorDest)BitConverter.ToUInt16(data, offset + 0x13E);
                Unknown140 = BitConverter.ToUInt32(data, offset + 0x140);
                Unknown144 = BitConverter.ToUInt32(data, offset + 0x144);
                Unknown148 = BitConverter.ToUInt32(data, offset + 0x148);
                Unknown150 = BitConverter.ToUInt32(data, offset + 0x150);
                Unknown154 = BitConverter.ToUInt32(data, offset + 0x154);
                Float158 = BitConverter.ToSingle(BitConverter.GetBytes(BitConverter.ToUInt32(data, offset + 0x158)), 0);

                if (BaseCTRChunk.IsMajora3D)
                {
                    Unknown15C = BitConverter.ToUInt16(data, offset + 0x15C);
                    Unknown15E = BitConverter.ToUInt16(data, offset + 0x15E);
                    Unknown160 = BitConverter.ToUInt16(data, offset + 0x160);
                    Unknown162 = BitConverter.ToUInt16(data, offset + 0x162);
                    Unknown164 = BitConverter.ToUInt16(data, offset + 0x164);
                    Unknown166 = BitConverter.ToUInt16(data, offset + 0x166);
                    Unknown168 = BitConverter.ToUInt32(data, offset + 0x168);
                }
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat("-- {0} --\n", this.GetType().Name);
                sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture,
                    "WARNING: Too many unknowns for me to bother dumping everything...\n" +
                    "Texture 0 -> ID: {0}, Min/Mag filter: {1}/{2}, Wrap mode S/T: {3}/{4}\n" +
                    "Texture 1 -> ID: {5}, Min/Mag filter: {6}/{7}, Wrap mode S/T: {8}/{9}\n" +
                    "Texture 2 -> ID: {10}, Min/Mag filter: {11}/{12}, Wrap mode S/T: {13}/{14}\n" +
                    "Blend factor source/destination: {15}/{16}\n" +
                    "Maybe alpha: {17} 0x{18:X}, maybe stencil: {19} 0x{20:X}\n",
                    TextureIDs[0], TextureMinFilters[0], TextureMagFilters[0], TextureWrapModeSs[0], TextureWrapModeTs[0],
                    TextureIDs[1], TextureMinFilters[1], TextureMagFilters[1], TextureWrapModeSs[1], TextureWrapModeTs[1],
                    TextureIDs[2], TextureMinFilters[2], TextureMagFilters[2], TextureWrapModeSs[2], TextureWrapModeTs[2],
                    BlendingFactorSrc, BlendingFactorDest,
                    MaybeAlphaFunction, MaybeAlphaUnknown130, MaybeStencilFunction, MaybeStencilUnknown134);
                sb.AppendLine();

                return sb.ToString();
            }
        }

        [System.Diagnostics.DebuggerDisplay("{GetType()}")]
        public class TexEnvStuff
        {
            public const int DataSize = 0x28;

            public ushort Unknown00 { get; private set; }
            public ushort Unknown02 { get; private set; }
            public ushort Unknown04 { get; private set; }
            public ushort Unknown06 { get; private set; }
            public ushort Unknown08 { get; private set; }
            public ushort Unknown0A { get; private set; }
            public ushort Unknown0C { get; private set; }
            public ushort Unknown0E { get; private set; }
            public ushort Unknown10 { get; private set; }
            public ushort Unknown12 { get; private set; }
            public ushort Unknown14 { get; private set; }
            public ushort Unknown16 { get; private set; }
            public ushort Unknown18 { get; private set; }
            public ushort Unknown1A { get; private set; }
            public ushort Unknown1C { get; private set; }
            public ushort Unknown1E { get; private set; }
            public ushort Unknown20 { get; private set; }
            public ushort Unknown22 { get; private set; }
            public ushort Unknown24 { get; private set; }
            public ushort Unknown26 { get; private set; }

            public TexEnvStuff(byte[] data, int offset)
            {
                Unknown00 = BitConverter.ToUInt16(data, offset);
                Unknown02 = BitConverter.ToUInt16(data, offset + 0x02);
                Unknown04 = BitConverter.ToUInt16(data, offset + 0x04);
                Unknown06 = BitConverter.ToUInt16(data, offset + 0x06);
                Unknown08 = BitConverter.ToUInt16(data, offset + 0x08);
                Unknown0A = BitConverter.ToUInt16(data, offset + 0x0A);
                Unknown0C = BitConverter.ToUInt16(data, offset + 0x0C);
                Unknown0E = BitConverter.ToUInt16(data, offset + 0x0E);
                Unknown10 = BitConverter.ToUInt16(data, offset + 0x10);
                Unknown12 = BitConverter.ToUInt16(data, offset + 0x12);
                Unknown14 = BitConverter.ToUInt16(data, offset + 0x14);
                Unknown16 = BitConverter.ToUInt16(data, offset + 0x16);
                Unknown18 = BitConverter.ToUInt16(data, offset + 0x18);
                Unknown1A = BitConverter.ToUInt16(data, offset + 0x1A);
                Unknown1C = BitConverter.ToUInt16(data, offset + 0x1C);
                Unknown1E = BitConverter.ToUInt16(data, offset + 0x1E);
                Unknown20 = BitConverter.ToUInt16(data, offset + 0x20);
                Unknown22 = BitConverter.ToUInt16(data, offset + 0x22);
                Unknown24 = BitConverter.ToUInt16(data, offset + 0x24);
                Unknown26 = BitConverter.ToUInt16(data, offset + 0x26);
            }
        }
    }
}
