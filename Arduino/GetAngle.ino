#include <MPU6050_tockn.h>
#include <Wire.h>

#define ledPin 3

MPU6050 mpu6050(Wire);

void setup() {
  Serial.begin(9600);
  Wire.begin();
  mpu6050.begin();
  pinMode(ledPin, OUTPUT);
  digitalWrite(ledPin, true);
  mpu6050.calcGyroOffsets(true);
  digitalWrite(ledPin, false);  
}

void loop() {
  mpu6050.update();
  String data = "";
  data = String(mpu6050.getAngleX()) + "," + String(mpu6050.getAngleY()) + "," + String(mpu6050.getAngleZ());
  Serial.println(data);
}
