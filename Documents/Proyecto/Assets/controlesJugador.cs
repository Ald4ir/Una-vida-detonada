using UnityEngine;

public class controlesJugador : MonoBehaviour {
    public float velocidad = 8f, velMax = 1.1f, fuerzaSalto = 3.8f, stamina = 100, limitacion, h;
    private Animator anim;
    private Rigidbody2D rigi;
    private BoxCollider2D col2D;
    public bool pisando, agachado, saltando, corriendo, enmochilado, enpistolado;
    private bool paso, suavemente, inventarioAbierto;
    public GameObject inventario;
    

	// Use this for initialization
	void Start () {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col2D = GetComponent<BoxCollider2D>();
        enmochilado = true;
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("velocidad", Mathf.Abs(rigi.velocity.x));
        anim.SetFloat("stamina", stamina);
        anim.SetBool("pisando", pisando);
        anim.SetBool("agacharse", agachado);
        anim.SetBool("corriendo", corriendo);
        anim.SetBool("Saltando", saltando);
        anim.SetBool("Enmochilado", enmochilado);
        
        if (Input.GetKeyDown(KeyCode.W) && pisando)
        {
            saltando = true;
            paso = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && pisando)
        {
            if (agachado)
            {
                agachado = false;
            }
            else
            {
                agachado = true;
            }
            paso = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            agachado = false;
            this.cambiarEstado();
            paso = true;
            if(!corriendo)
            {
                suavemente = true;                
            }
        }
        if((limitacion == 0 && paso) || !agachado )
        {
            this.cambiarBoxCollider();
        }
        if(Input.GetKeyDown(KeyCode.I) && enmochilado)
        {
            if(inventarioAbierto)
            {
                inventario.SetActive(false);
                inventarioAbierto = false;
            }
            else
            {
                inventario.SetActive(true);
                inventarioAbierto = true;
            }
        }
    }

    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        rigi.AddForce(Vector2.right * velocidad * h);
        limitacion = Mathf.Clamp(rigi.velocity.x, -velMax, velMax);
        if(corriendo)
        {
            limitacion *= .999999f;
        }
        if(suavemente && !corriendo)
        {
            this.reducirVelocidad();
        }
        if (Mathf.Abs(limitacion) <= 0.1f)
        {
            if (!suavemente)
            {
                velMax = 1.1f;
            }
            fuerzaSalto = 3.8f;
            corriendo = false;
        }
        rigi.velocity = new Vector2(limitacion, rigi.velocity.y);
        if(saltando || Mathf.Abs(limitacion) > 0.1)
        {
            agachado = false;
        }
        if (h > 0.1f && pisando)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            if(h < -0.1f && pisando)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        
        if(saltando)
        {
            rigi.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltando = false;
            agachado = false;
            this.cambiarBoxCollider();
        }

    }

    public void cambiarEstado()
    {
        if (corriendo && pisando)
        {
            fuerzaSalto = 3.8f;
            corriendo = false;
        }
        else
        {
            if(stamina > 25)
            {
                velMax = 9f;
                fuerzaSalto = 4.4f;
                corriendo = true;
            }
        }
    }

    public void cambiarEstado(bool cambiar)
    {
        if(corriendo && cambiar)
        {
            velMax = 1.1f;
            fuerzaSalto = 3.8f;
            corriendo = false;
        }
    }

   public void reducirVelocidad()
    {
        if(velMax > 1.1f)
        {
            velMax -= (Time.deltaTime * 5);
        }
        if(velMax < 1.1f)
        {
            velMax = 1.1f;
            suavemente = false;
        }
    }

    private void cambiarBoxCollider()
    {
        if (agachado && pisando)
        {
            col2D.size = new Vector2(col2D.size.x, 1.292634f);
            col2D.offset = new Vector2(col2D.offset.x, -0.6026926f);
        }
        else
        {
            if (pisando)
            {
                col2D.size = new Vector2(col2D.size.x, 2.319931f);
                col2D.offset = new Vector2(col2D.offset.x, -0.08904433f);
            }
        } 
    }
}
