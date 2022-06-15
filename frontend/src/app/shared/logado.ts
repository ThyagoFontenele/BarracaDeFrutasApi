import { Usuario } from "./usuario";

export abstract class Logado{

  private static usuario?: Usuario;

  public static logar(usuario: Usuario) {
    if(usuario){
      return;
    }
    this.usuario = usuario;
  }

  public static usuarioLogado(): Usuario | undefined {
    return Logado.usuario;
  }
}
