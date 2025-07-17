using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // 玩家移动速度
    public float Speed = 6f;
    /// <summary>
    /// 物体进行移动更新，一般在这个Update()函数中更新
    /// 但是一般涉及到角色的移动，我们通过Rigidbody来进行角色的修改，
    /// 一般是物理的这种形式建议写在fixedUpdate()中
    /// </summary>


    //代表当前的Rigidbody这个组件
    private Rigidbody rb;
    //动画控制器当中的IsWalking参数，进行角色动画的切换
    private Animator anim;     

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }


    //更新角色移动
    private void FixedUpdate()
    {
        //角色这里离只进行前后左右移动，y轴不需要进行移动，不需要控制速度
        //一个横向轴，一个纵向轴
        //获取  输入管理器里的那个轴线的信息

        //不按就是获取到0，按了就是获取到1，没有中间的替代量，不需要按了一段时间后，这个获取量才会变化
        float h = Input.GetAxisRaw("Horizontal");  
        float v = Input.GetAxisRaw("Vertical");

        //移动
        Move(h,v);

        //旋转
        Turning();

        //切换动画
        Animating(h,v);
    }


    #region 移动
    void Move(float h,float v)
    {

        //input.getaxisraw，获取操作设备输入
        //因为  输入管理器中，都是Horizontal和Vertical来获取水平位置和垂直位置的
        //获取到这两个值后，需要构建一个三维的向量
        Vector3 movementV3 = new Vector3(h, 0, v);      //因为y轴不动,不需要向上移动，x 0 z 三维向量

        //需要构造一下向量的大小，也就是h 和 v的大小，这两个轴最大是1，最小是0，

        movementV3 = movementV3.normalized * Speed * Time.deltaTime;

        //
        rb.MovePosition(transform.position + movementV3);
    }
    #endregion




    #region 旋转
    void Turning()
    {
        //不需要获取h和v，因为旋转是根据鼠标来进行旋转的
        //创建相机射线(鼠标位置)，通过鼠标向屏幕中发射的一条射线
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);     

        int floorLayer = LayerMask.GetMask("Floor");  //Floor区分大小写

        RaycastHit floorHit;
         
        //获取图层id
        //Debug.Log(floorLayer);

        //射线检测,这里Raycast需要穿一个图层的ID给他，100这个参数是射线的长度
        bool isTouchFloor =  Physics.Raycast(cameraRay, out floorHit, 100, floorLayer);

        //检测射线是否触碰到地面
        if (isTouchFloor)
        {
            Vector3 v3 = floorHit.point - transform.position;
            v3.y = 0;

            Quaternion quaternion = Quaternion.LookRotation(v3);
            rb.MoveRotation(quaternion);
        }
    }
    #endregion


    #region 切换角色动画
    void Animating(float h ,float v)
    {
        //默认动画是idle，一旦变成true就是变成Move，也就是一旦控制角色移动，动画就从false变成true
        bool isW = false;
        //横轴和纵轴不能单独的大于零或者小于零。因为方向(坐标)W是大于零，S是小于零的
        {
            if ( h != 0 || v != 0)   
            isW = true;
        }

        anim.SetBool("IsWalking",isW);
    }

    #endregion


























}
