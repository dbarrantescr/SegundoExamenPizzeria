# Turn on execshield
kernel.exec-shield=1
kernel.randomize_va_space=1

# Enable IP spoofing protection
net.ipv4.conf.all.rp_filter=1

# Disable IP source routing
net.ipv4.conf.all.accept_source_route=0

# Ignoring broadcasts request
net.ipv4.icmp_echo_ignore_broadcasts=1
net.ipv4.icmp_ignore_bogus_error_messages=1

# Make sure spoofed packets get logged
net.ipv4.conf.all.log_martians = 1
net.ipv4.conf.default.log_martians = 1

# Disable ICMP routing redirects
sysctl -w net.ipv4.conf.all.accept_redirects=0
sysctl -w net.ipv6.conf.all.accept_redirects=0
sysctl -w net.ipv4.conf.all.send_redirects=0
sysctl -w net.ipv6.conf.all.send_redirects=0

# Disables the magic-sysrq key
kernel.sysrq = 0

# Turn off the tcp_sack
net.ipv4.tcp_sack = 0

# Turn off the tcp_timestamps
net.ipv4.tcp_timestamps = 0

# Enable TCP SYN Cookie Protection
net.ipv4.tcp_syncookies = 1

# Enable bad error message Protection
net.ipv4.icmp_ignore_bogus_error_responses = 1
