using System;
using System.Collections.Generic;
public static class TelemetryBuffer
{
    private static byte[] toByteArr(long number, int num_bytes, byte header)
    {
        byte[] data_bytes=BitConverter.GetBytes(number);
        byte[] ans=new byte[9];
        ans[0]=header;
        for(int i=0; i<num_bytes;++i) {
            ans[i+1]=data_bytes[i];
        }
        return ans;
    }
    public static byte[] ToBuffer(long reading)
    {
        if(reading<=-2_147_483_649L) 
            return toByteArr(reading,8,256-8);
        else if (reading<=-32_769L)
            return toByteArr(reading,4,256-4);
        else if (reading<=-1)
            return toByteArr(reading,2,256-2);
        else if(reading<=65_535)
            return toByteArr(reading,2,2);
        else if(reading<=2_147_483_647L)
            return toByteArr(reading,4,256-4);
        else if(reading<=4_294_967_295L)
            return toByteArr(reading,4,4);
        else 
            return toByteArr(reading,8,256-8);
        return null;
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte header=buffer[0];
        if(header!=256-8 && header!=256-4 && header!=256-2 && header!=2 && header!=4)
            return 0;
        if(header==248)
            return BitConverter.ToInt64(buffer,1);
        else if (header==256-4)
            return BitConverter.ToInt32(buffer,1);
        else if(header==256-2)
            return BitConverter.ToInt16(buffer,1);
        else if(header==2)
            return BitConverter.ToUInt16(buffer,1);
        else 
            return BitConverter.ToUInt32(buffer,1);
    }
}
