import { Pedido } from "./pedido";
import { Produto } from "./produto";

export interface ItemPedido {
  id?: number;
  pedido: Pedido;
  produto: Produto;
  quantidade: number;
  valor: number;
}
