using System;

class RemoteControlCar
{
    int speed, batteryDrain;
    int distanceDriven=0, battery=100;
    // TODO: define the constructor for the 'RemoteControlCar' class
    public RemoteControlCar(int speed, int batteryDrain=0) {
        this.speed=speed;
        this.batteryDrain=batteryDrain;
    }
    public bool BatteryDrained()
    {
        return battery<batteryDrain;
    }

    public int DistanceDriven()
    {
        return distanceDriven;
    }

    public void Drive()
    {
        if(battery>=batteryDrain){
            distanceDriven+=speed;
            battery-=batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50,4);
    }

    public int maxDistance() {
        return speed*battery/batteryDrain;
    }
}

class RaceTrack
{
    int distance;
    // TODO: define the constructor for the 'RaceTrack' class
    public RaceTrack(int distance){
        this.distance=distance;
    }
    public bool CarCanFinish(RemoteControlCar car)
    {
        return car.maxDistance()>=distance;
    }
}
