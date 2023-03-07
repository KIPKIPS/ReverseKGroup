using System;
using System.Collections.Generic;

namespace ReverseKGroup {
    class Program {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }

        static void Main(string[] args) {
            List<ListNode> list = new List<ListNode>();
            list.Add(new ListNode(1));
            list.Add(new ListNode(2));
            list.Add(new ListNode(3));
            list.Add(new ListNode(4));
            list.Add(new ListNode(5));
            for (int i = 0; i < list.Count - 1; i++) {
                list[i].next = list[i + 1];
            }
            ListNode head = ReverseKGroup(list[0], 3);
            // Revert(list[0],2);
            // ListNode head = Revert(list[0], 3);
            ListNode cur = head;
            while (cur != null) {
                Console.WriteLine(cur.val);
                cur = cur.next;
            }
            
            Console.ReadLine();
        }
        public static ListNode ReverseKGroup(ListNode head, int k) {
            ListNode cur = head;
            int cnt = 0;
            ListNode tHead = null;
            ListNode lastHead = null;
            ListNode res = null;
            while (cur != null) {
                if (cnt == 0) {
                    tHead = cur;
                }
                if (cnt == k - 1) {
                    ListNode next = cur.next;//缓存下一个节点
                    ListNode newHead = Revert(tHead, k);
                    if (lastHead != null) {
                        lastHead.next = newHead;
                    }
                    if (res == null) {
                        res = newHead;
                    }
                    tHead.next = next;
                    cur = tHead;
                    lastHead = tHead;
                    cnt = 0;
                } else {
                    cnt++;
                }
                cur = cur.next;
            }
            res = res == null ? head : res;
            return res;
        }

        public static ListNode Revert(ListNode head, int k) {
            if (head == null) {
                return head;
            }
            ListNode[] arr = new ListNode[k];
            for (int i = 0; i < k; i++) {
                arr[i] = head;
                head = head.next;
            }
            for (int i = 0; i < k - 1; ++i) {
                arr[i + 1].next = arr[i];
            }
            return arr[k - 1];
        }
    }
}