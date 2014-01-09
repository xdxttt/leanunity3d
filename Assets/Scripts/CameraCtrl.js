
var ZoomSpeed = 30;//镜头缩放速率
var MovingSpeed = 1;//镜头移动速率
var RotateSpeed = 1;  //镜头旋转速率
private var distance = 0.0f;//保存镜头和中心点的直线距离
  
function Start () {
    distance = Mathf.Abs(transform.position.y/Mathf.Sin(transform.eulerAngles.x));
}
  
function LateUpdate () {
    var rotation;
    var position;
  
    //按住鼠标左键移动鼠标拖动镜头，改成键盘输入或者鼠标靠近屏幕边缘输入都是可以的   
    if(Input.GetMouseButton(0))
    {
        var delta_x = Input.GetAxis("Mouse X") * MovingSpeed;
         var delta_y = Input.GetAxis("Mouse Y") * MovingSpeed;
  
        //镜头其实就是在平行地面的水平面上四处移动 所以构造一个变换矩阵 与世界坐标唯一的差异就是y轴旋转的角度
        rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y,0 );
        //把镜头要移动的分量乘以这个变化矩阵就是相对世界坐标的移动量啦 再加上镜头当前坐标 就是镜头新位置啦
        transform.position =rotation * Vector3(-delta_x,0,-delta_y)+transform.position;
      }
  
            //用滚轮控制镜头拉伸和推进
      if(Input.GetAxis("Mouse ScrollWheel")){   
          var delta_z = -Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
          //直接用镜头的translate函数在镜头参考系Z方向上运动就可以啦
        transform.Translate(0,0,-delta_z);
        //再用delta_z修正镜头与视野中心点的距离 其实不记录也是可以的 每次都用sin算比较麻烦
        distance += delta_z;
    }
  
      //按住鼠标右键移动鼠标旋转镜头
      if (Input.GetMouseButton(1)) {
        var delta_rotation_x = Input.GetAxis("Mouse X") * RotateSpeed;
        var delta_rotation_y = -Input.GetAxis("Mouse Y") * RotateSpeed;
  
       //旋转是以镜头当前视野中心点为原点进行的 在一个平行于地面的水平面上旋转
  
       //先算出当前视野中心的坐标，中心的概念就是正对 上下左右都对齐，离开一个distance距离
       //所以中心点相对镜头参照系的坐标就是0,0,distance,乘以镜头的变换,在加上镜头的世界坐标 就是中心点的世界坐标了
       position =transform.rotation* Vector3(0,0,distance)+transform.position;
  
       //Y轴方向上用世界坐标的变换就可以拉 否则镜头会歪的       
       transform.Rotate(0,delta_rotation_x,0,Space.World);
       //x轴方向的旋转是相对自身的 否则镜头也会歪
       transform.Rotate(delta_rotation_y,0,0);
       //转完以后 把这个新的旋转角度 乘以一个“正对中心”的相对坐标 再加上中心点的坐标 就是新的镜头世界坐标啦
       transform.position =transform.rotation* Vector3(0,0,-distance)+position;
     }
}