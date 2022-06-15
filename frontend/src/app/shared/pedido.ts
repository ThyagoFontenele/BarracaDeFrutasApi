import { ItemPedido } from "./item-pedido";
import { Usuario } from "./usuario";

export interface Pedido {
  id?: number;
  cliente: Usuario;
  items: ItemPedido[];
  data: Date | null;
  total: number;
  finalizado: boolean;
}
