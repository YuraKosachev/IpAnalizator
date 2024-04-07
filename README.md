### Simple console app
#### Console input parameters
```
--file-log D:\TestFiles\20240406200023\20240406200025.txt --file-output D:\\analizer_log.txt
--address-stat 100.0.0.0 --address-mask 255.0.0.255 --time-start 19.04.2022 --time-end 29.05.2023
```

#### AppConfig parameters 
```
{
  "file-log": "D:\\TestFiles\\20240406200023\\20240406200025.txt",
  "file-output": "D:\\output",
  "address-start": "0.0.100.0",
  "address-mask": "255.0.0.0",
  "time-start": "24.01.2023",
  "time-end": "24.01.2024"
}
```

#### Parameters description

| Parameter      | Description | Is Required    | Example |
| :---        |    :----:   |          ---: |          ---: |
| file-log     | Path to input file      | Yes  |D:\\test\\test\\test.txt|
| file-output   | Path to output file       | Yes      |D:\\output  OR D:\\output\output.txt|
| address-start   | Search range's start value Ip      | No     |0.0.100.0|
| address-mask   | Search range's end value Ip       | No      |255.0.0.0|
| time-start   | Search range's start value date    | No      |24.01.2023|
| time-end   | Search range's end value date       | No      |24.01.2024|
