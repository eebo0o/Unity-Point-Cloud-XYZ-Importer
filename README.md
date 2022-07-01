# Point Cloud Importer
Pcx - Point Cloud Importer/Renderer for Unity
GIF
 GIF

Pcx is a custom importer and renderer that allows for handling point cloud data in Unity.

System Requirements
Unity 2019.4
Supported Formats
Currently Pcx only supports PLY binary little-endian format.

How To Install
The Pcx package uses the scoped registry feature to import dependent packages. Please add the following sections to the package manifest file (Packages/manifest.json).

To the scopedRegistries section:

{
  "name": "Keijiro",
  "url": "https://registry.npmjs.com",
  "scopes": [ "jp.keijiro" ]
}
To the dependencies section:

"jp.keijiro.pcx": "1.0.1"
After changes, the manifest file should look like below:

{
  "scopedRegistries": [
    {
      "name": "Keijiro",
      "url": "https://registry.npmjs.com",
      "scopes": [ "jp.keijiro" ]
    }
  ],
  "dependencies": {
    "jp.keijiro.pcx": "1.0.1",
    ...
Container Types
Inspector

There are three types of container for point clouds.

Mesh
Points are to be contained in a Mesh object. They can be rendered with the standard MeshRenderer component. It's recommended to use the custom shaders included in Pcx (Point Cloud/Point and Point Cloud/Disk).

ComputeBuffer
Points are to be contained in a PointCloudData object, which uses ComputeBuffer to store point data. It can be rendered with using the PointCloudRenderer component.

Texture
Points are baked into Texture2D objects that can be used as attribute maps in Visual Effect Graph.

Rendering Methods
There are two types of rendering methods in Pcx.

Point (point primitives)
Points are rendered as point primitives when using the Point Cloud/Point shader.

Points Points

The size of points can be adjusted by changing the material properties.

Inspector

These size properties are only supported on some platforms; It may work with OpenGLCore and Metal, but never work with D3D11/12.

This method is also used when the point size is set to zero in PointCloudRenderer.

Disk (geometry shader)
Points are rendered as small disks when using the Point Cloud/Disk shader or PointCloudRenderer.

Disks

This method requires geometry shader support.

Acknowledgements
The point cloud files used in the examples of Pcx are created by authors listed below. These files are licensed under the Creative Commons Attribution license (CC BY 4.0). Please see the following original pages for further details.

richmond-azaelias.ply - Azaleas, Isabella Plantation, Richmond Park. Created by Thomas Flynn. https://sketchfab.com/models/188576acfe89480f90c38d9df9a4b19a

anthidium-forcipatum.ply - Anthidium forcipatum ♀ (Point Cloud). Created by Thomas Flynn. https://sketchfab.com/models/3493da15a8db4f34929fc38d9d0fcb2c

Guanyin.ply - Guanyin (Avalokitesvara). Created by Geoffrey Marchal. https://sketchfab.com/models/9db9a5dfb6744a5586dfcb96cb8a7dc5
