# Point Cloud Importer XYZ
For Every one Interested in 3D scanning either (laser/photogrammetry) and want to use there scanned data in a game or to do more theoretical simulations.

This plugin is the link between the point cloud exporter applications and Unity 3D without the need for a 3D converter applications or long processes and hard work.
Based on Pcx - Point Cloud Importer/Renderer for Unity Free Plugin https://github.com/keijiro/Pcx#pcx---point-cloud-importerrenderer-for-unity

System Requirements Unity 2017.3 and above.
Tested on 2017.3/2021.3 versions.

![68747470733a2f2f692e696d6775722e636f6d2f7a6336503936782e676966](https://user-images.githubusercontent.com/12146382/176805316-83b74c04-675c-4c30-9266-7e3004a84cc5.gif)

![Capture](https://user-images.githubusercontent.com/12146382/176805325-293526dc-f8d0-4d8d-910b-2bbde38f6d36.PNG)


Supported Formats Currently the Plugin only supports PLY,XYZ,XYZRGB format. XYZ files has to be [ASC] point, color format.

Can support Files with size 2GB and around 48M point. For now if you need to import larger files you can split the large file into small files that can be imported then use them as a separate models.

There are 2 types of container for point clouds.

Mesh Points are to be contained in a Mesh object. They can be rendered with the standard Mesh Renderer component. It's recommended to use the custom shaders included in Pcx (Point Cloud/Point and Point Cloud/Disk).

Compute Buffer Points are to be contained in a Point Cloud Data object, which uses Compute Buffer to store point data. It can be rendered with using the Point Cloud Renderer component.

---------------------------------------------------------------------------------------------

These Plugin are licensed under the Creative Commons Attribution license ([CC BY 4.0](https://creativecommons.org/licenses/by/4.0/)).

---------------------------------------------------------------------------------------------
