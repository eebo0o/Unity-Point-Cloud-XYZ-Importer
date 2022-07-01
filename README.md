# Point Cloud Importer XYZ
Based on Pcx - Point Cloud Importer/Renderer for Unity Free Plugin
  https://github.com/keijiro/Pcx#pcx---point-cloud-importerrenderer-for-unity

System Requirements
Unity 2017.3 and above
Tested on 2017.3/2021.3 versions

![68747470733a2f2f692e696d6775722e636f6d2f7a6336503936782e676966](https://user-images.githubusercontent.com/12146382/176805316-83b74c04-675c-4c30-9266-7e3004a84cc5.gif)

![Capture](https://user-images.githubusercontent.com/12146382/176805325-293526dc-f8d0-4d8d-910b-2bbde38f6d36.PNG)


Supported Formats
Currently the Plugin only supports PLY,XYZ,XYZRGB format.
XYZ files has to be [ASC] point, color format.

Can support Files with size 2GB and arround 48M point.

There are 2 types of container for point clouds.

Mesh
Points are to be contained in a Mesh object. They can be rendered with the standard MeshRenderer component. It's recommended to use the custom shaders included in Pcx (Point Cloud/Point and Point Cloud/Disk).

ComputeBuffer
Points are to be contained in a PointCloudData object, which uses ComputeBuffer to store point data. It can be rendered with using the PointCloudRenderer component.
